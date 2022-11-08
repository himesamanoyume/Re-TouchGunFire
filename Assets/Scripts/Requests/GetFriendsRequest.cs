using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;

public class GetFriendsRequest : IRequest
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
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("请求好友列表成功");
            break;
            case ReturnCode.Fail:
                Debug.Log("请求好友列表失败");
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
