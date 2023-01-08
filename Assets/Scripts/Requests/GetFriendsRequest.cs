using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class GetFriendsRequest : IRequest
{
    public override void Awake()
    {
        Name = "GetFriendsRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.GetFriends;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("请求好友列表成功");
                    // panelMediator.ShowNotifyPanel("请求好友列表成功",3f);
                    // FriendsPanelInfo friendsPanelInfo = panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>();
                    // friendsPanelInfo.GetFriendsCallback(mainPack.FriendsPack);
                    networkMediator.GetFriendsCallback(mainPack.FriendsPack);
                break;
                case ReturnCode.Fail:
                    // Debug.Log("请求好友列表失败");
                    panelMediator.ShowNotifyPanel("请求好友列表失败",3f);
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
