using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public class SearchFriendRequest : IRequest
{
    public override void Awake()
    {
        Name = "FriendRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.SearchFriend;
        base.Awake();
        networkMediator = GameLoop.Instance.GetMediator<NetworkMediator>();
        panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
    }

    public NetworkMediator networkMediator;
    public PanelMediator panelMediator;

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("搜索玩家成功");
                Loom.QueueOnMainThread(()=>{
                    panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().ResponseCallback(mainPack);
                });
                
            break;
            case ReturnCode.Fail:
                Debug.Log("搜索玩家失败");
            break;
            case ReturnCode.ReturnNone:
                Debug.LogError("不正常情况");
            break;
        }
    }

    public void SendRequest(int targetPlayerUid)
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.uid;
        PlayerInfoPack playerInfoPack = new PlayerInfoPack();
        playerInfoPack.Uid = targetPlayerUid;
        mainPack.PlayerInfoPack = playerInfoPack;
        
        base.TcpSendRequest(mainPack);
    }
}
