using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class GetFriendRequestRequest : IRequest
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
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("请求添加好友申请列表成功");
                    // panelMediator.ShowNotifyPanel("请求添加好友申请列表成功",3f);
                    // FriendsPanelInfo friendsPanelInfo = panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>();
                    // friendsPanelInfo.GetFriendRequestCallback(mainPack.FriendsPack);
                    networkMediator.GetFriendRequestCallback(mainPack.FriendsPack);
                break;
                case ReturnCode.Fail:
                    // Debug.Log("请求添加好友申请列表失败");
                    panelMediator.ShowNotifyPanel("请求添加好友申请列表失败",3f);
                break;
                case ReturnCode.ReturnNone:
                    // Debug.LogError("不正常情况");
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }

    public void SendRequest()
    {
        MainPack mainPack = base.InitRequest();
        
        base.TcpSendRequest(mainPack);
    }
}
