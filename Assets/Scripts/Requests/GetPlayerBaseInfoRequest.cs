using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;
using Google.Protobuf.Collections;

public class GetPlayerBaseInfoRequest : IRequest
{
    public override void Awake()
    {
        Name = "GetPlayerBaseInfoRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.GetPlayerBaseInfo;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("请求获取玩家基本信息成功");
            
                Loom.QueueOnMainThread(()=>{
                    friendPlayerInfoBarInfoList.TryGetValue(mainPack.PlayerInfoPack.Uid,out FriendPlayerInfoBarInfo friendPlayerInfoBarInfo);
                    friendPlayerInfoBarInfo.GetPlayerBaseInfoCallback(mainPack.PlayerInfoPack);
                    friendPlayerInfoBarInfoList.Remove(mainPack.PlayerInfoPack.Uid);
                });
                
            break;
            case ReturnCode.Fail:
                Debug.Log("请求获取玩家基本信息失败");
            break;
            case ReturnCode.ReturnNone:
                Debug.LogError("不正常情况");
            break;
        }
    }

    Dictionary<int, FriendPlayerInfoBarInfo> friendPlayerInfoBarInfoList = new Dictionary<int,FriendPlayerInfoBarInfo>();

    public void SendRequest(int targetPlayerUid, FriendPlayerInfoBarInfo friendPlayerInfoBarInfo)
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.uid;
        PlayerInfoPack playerInfoPack = new PlayerInfoPack();
        playerInfoPack.Uid = targetPlayerUid;
        mainPack.PlayerInfoPack = playerInfoPack;
        friendPlayerInfoBarInfoList.Add(targetPlayerUid, friendPlayerInfoBarInfo);
        base.TcpSendRequest(mainPack);
    }
}
