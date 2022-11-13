using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class LeaveTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "LeaveTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.LeaveTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    if (mainPack.PlayerInfoPack.Uid == networkMediator.playerSelfUid)
                    {
                        panelMediator.ShowNotifyPanel("你已离队",1f);
                    }else
                    {
                        panelMediator.ShowNotifyPanel("有队员离队",1f);
                    }
                    
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("离队失败",3f);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(){
        MainPack mainPack = base.InitRequest();
        base.TcpSendRequest(mainPack);
    }

}
