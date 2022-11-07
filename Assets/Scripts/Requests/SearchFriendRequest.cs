using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;

public class SearchFriendRequest : IRequest
{
    public override void Awake()
    {
        Name = "FriendRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.SearchFriend;
        base.Awake();
        networkMediator = GameLoop.Instance.GetMediator<NetworkMediator>();
    }

    public NetworkMediator networkMediator;

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                
            break;
            case ReturnCode.Fail:
                
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
        
        
        base.TcpSendRequest(mainPack);
    }
}
