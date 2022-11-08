using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;
using Google.Protobuf.Collections;

public class GetFriendRequestRequest : IRequest
{
    public override void Awake()
    {
        Name = "GetFriendRequestRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.GetFriendRequest;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("请求添加好友申请列表成功");
            
                Loom.QueueOnMainThread(()=>{
                    FriendsPanelInfo friendsPanelInfo = panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>();
                    friendsPanelInfo.GetFriendRequestCallback(mainPack.FriendsPack);
                });
                
            break;
            case ReturnCode.Fail:
                Debug.Log("请求添加好友申请列表失败");
            break;
            case ReturnCode.ReturnNone:
                Debug.LogError("不正常情况");
            break;
        }
    }

    public void SendRequest()
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.uid;
        
        base.TcpSendRequest(mainPack);
    }
}
