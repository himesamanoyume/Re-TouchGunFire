using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class AttackInvitedRequest : IRequest
{
    public override void Awake()
    {
        Name = "AttackInvitedRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.AttackInvited;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("离开战斗请求成功");
                    // networkMediator.AttackLeaveCallback();
                    
                break;
                case ReturnCode.Fail:
                    
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }
}
