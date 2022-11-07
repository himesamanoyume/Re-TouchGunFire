using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;


public class SendRequestFriendRequest : IRequest
{
    public override void Awake()
    {
        Name = "SendRequestFriendRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.SendRequestFriend;
        base.Awake();
        networkMediator = GameLoop.Instance.GetMediator<NetworkMediator>();
    }

    public NetworkMediator networkMediator;

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("添加好友请求发送成功");
            break;
            case ReturnCode.Fail:
                Debug.Log("添加好友请求发送失败");
            break;
            case ReturnCode.RepeatedRequest:
                Debug.Log("玩家之间已为好友或已发送过添加好友请求");
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
        SendRequestFriendPack sendRequestFriendPack = new SendRequestFriendPack();
        sendRequestFriendPack.TargetPlayerUid = targetPlayerUid;
        mainPack.SendRequestFriendPack = sendRequestFriendPack;
        
        base.TcpSendRequest(mainPack);
    }
}
