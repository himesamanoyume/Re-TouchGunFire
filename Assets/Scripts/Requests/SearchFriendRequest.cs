using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class SearchFriendRequest : IRequest
{
    public override void Awake()
    {
        Name = "FriendRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.SearchFriend;
        base.Awake();
        
    }



    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("搜索玩家成功");
                    // panelMediator.ShowNotifyPanel("搜索玩家成功",3f);
                    panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().SearchFriendCallback(mainPack);
                break;
                case ReturnCode.Fail:
                    // Debug.Log("搜索玩家失败");
                    panelMediator.ShowNotifyPanel("搜索玩家失败",3f);
                break;
                case ReturnCode.RepeatedRequest:
                    panelMediator.ShowNotifyPanel("你无法搜索自己的信息",3f);
                break;
                case ReturnCode.ReturnNone:
                    // Debug.LogError("不正常情况");
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }

    public void SendRequest(int targetPlayerUid)
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.playerSelfUid;
        PlayerInfoPack playerInfoPack = new PlayerInfoPack();
        playerInfoPack.Uid = targetPlayerUid;
        mainPack.PlayerInfoPack = playerInfoPack;
        
        base.TcpSendRequest(mainPack);
    }
}
