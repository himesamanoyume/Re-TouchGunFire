using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class JoinTeamRequestRequest : IRequest
{
    public override void Awake()
    {
        Name = "JoinTeamRequestRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.JoinTeamRequest;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

}
