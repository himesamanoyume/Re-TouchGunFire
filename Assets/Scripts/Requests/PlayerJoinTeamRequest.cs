using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class PlayerJoinTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "PlayerJoinTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.PlayerJoinTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:

                    Debug.Log("PlayerJoinTeamRequest Success");
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
