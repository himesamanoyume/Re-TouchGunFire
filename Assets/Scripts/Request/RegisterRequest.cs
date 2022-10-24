using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public class RegisterRequest : IRequest
{
    public override void Awake() {
        Name = "RegisterRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.Register;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
                Debug.Log("Register Success.");
            break;
            case ReturnCode.Fail:
                Debug.LogWarning("Register Failed.");
            break;
        }
    }

    /// <summary>
    /// 发送注册请求
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    public void SendRequest(string userName, string password)
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        RegisterPack registerPack = new RegisterPack();
        registerPack.UserName = userName;
        registerPack.Password = password;
        mainPack.RegisterPack = registerPack;
        base.SendRequest(mainPack);
    }
}