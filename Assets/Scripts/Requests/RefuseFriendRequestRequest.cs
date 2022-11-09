using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class RefuseFriendRequestRequest : IRequest
{
    public override void Awake()
    {
        Name = "RefuseFriendRequestRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.RefuseFriendRequest;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("拒绝添加好友请求成功");
                Loom.QueueOnMainThread(()=>{
                    friendPlayerInfoBarInfoList.TryGetValue(mainPack.PlayerInfoPack.Uid,out FriendPlayerInfoBarInfo friendPlayerInfoBarInfo);
                    friendPlayerInfoBarInfo.RefuseFriendRequestCallback();
                    friendPlayerInfoBarInfoList.Remove(mainPack.PlayerInfoPack.Uid);
                });
            break;
            case ReturnCode.Fail:
                Debug.Log("拒绝添加好友请求失败");
            break;
            case ReturnCode.NotFound:
                Debug.Log("未找到该好友添加请求");
            break;
            default:
                Debug.LogError("不正常情况");
            break;
        }
    }

    Dictionary<int, FriendPlayerInfoBarInfo> friendPlayerInfoBarInfoList = new Dictionary<int,FriendPlayerInfoBarInfo>();

    public void SendRequest(int targetPlayerUid, FriendPlayerInfoBarInfo friendPlayerInfoBarInfo){
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
