using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using Google.Protobuf.Collections;

public class GetFriendRequestRequest : IRequest
{
    public override void Awake()
    {
        Name = "GetFriendRequestRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.GetFriendRequest;
        base.Awake();
        networkMediator = GameLoop.Instance.GetMediator<NetworkMediator>();
    }

    public NetworkMediator networkMediator;

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("请求添加好友申请列表成功");
                RepeatedField<FriendsPack> friendsPacks = mainPack.FriendsPack;
                foreach (var item in friendsPacks)
                {
                    Debug.Log(item.Player1Uid);
                }
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
