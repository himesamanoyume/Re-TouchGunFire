using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;

public sealed class LoginRequest : IRequest
{
    public override void Awake() {
        Name = "LoginRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            Debug.Log(mainPack.ReturnCode);
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    networkMediator.playerSelfUid = mainPack.Uid;
                    Debug.Log(mainPack.Uid);
                    networkMediator.OnUserLoginSuccess();
                break;
                case ReturnCode.Fail:
                    networkMediator.OnUserLoginFail();
                break;
                case ReturnCode.ReturnNone:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                    // Debug.LogError("不正常情况");
                break;
            }
        });
    }

    /// <summary>
    /// 发送登陆请求
    /// </summary>
    /// <param name="account"></param>
    /// <param name="password"></param>
    public void SendRequest(string account, string password)
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        LoginPack loginPack = new LoginPack();
        loginPack.Account = account;
        loginPack.Password = password;
        mainPack.LoginPack = loginPack;
        base.TcpSendRequest(mainPack);
    }
}