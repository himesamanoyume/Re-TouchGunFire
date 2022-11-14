using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;

public sealed class RegisterRequest : IRequest
{
    public override void Awake() {
        Name = "RegisterRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.Register;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    panelMediator.ShowNotifyPanel("注册成功",2f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("注册失败~可能账号已被注册",2f);
                break;
                case ReturnCode.ReturnNone:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                    // Debug.LogError("不正常情况");
                break;
            }
        });
    }

    /// <summary>
    /// 发送注册请求
    /// </summary>
    /// <param name="playerName"></param>
    /// <param name="account"></param>
    /// <param name="password"></param>
    public void SendRequest(string playerName, string account, string password)
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        RegisterPack registerPack = new RegisterPack();
        registerPack.PlayerName = playerName;
        registerPack.Account = account;
        registerPack.Password = password;
        mainPack.RegisterPack = registerPack;
        base.TcpSendRequest(mainPack);
    }
}