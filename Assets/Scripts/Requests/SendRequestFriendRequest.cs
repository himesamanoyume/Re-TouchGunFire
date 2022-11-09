using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;


public sealed class SendRequestFriendRequest : IRequest
{
    public override void Awake()
    {
        Name = "SendRequestFriendRequest";
        requestCode = RequestCode.Friend;
        actionCode = ActionCode.SendRequestFriend;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("添加好友请求发送成功");
                    panelMediator.ShowNotifyPanel("添加好友请求发送成功", 3f);
                break;
                case ReturnCode.Fail:
                    // Debug.Log("添加好友请求发送失败");
                    panelMediator.ShowNotifyPanel("添加好友请求发送失败", 3f);
                break;
                case ReturnCode.RepeatedRequest:
                    // Debug.Log("玩家之间已为好友或已发送过添加好友请求");
                    panelMediator.ShowNotifyPanel("玩家之间已为好友或已发送过添加好友请求", 3f);
                break;
                case ReturnCode.ReturnNone:
                    // Debug.LogError("不正常情况");
                    panelMediator.ShowNotifyPanel("不正常情况", 3f);
                break;
            }
        });
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
