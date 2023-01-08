using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class AttackEndRequest : IRequest
{
    public override void Awake()
    {
        Name = "AttackEndRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.AttackEnd;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    networkMediator.AttackEndCallback();
                    panelMediator.ShowNotifyPanel("战斗胜利结束!",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

}
