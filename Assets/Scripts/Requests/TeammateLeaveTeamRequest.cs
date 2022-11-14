using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;
using ReTouchGunFire.Mediators;

public sealed class TeammateLeaveTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "TeammateLeaveTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.TeammateLeaveTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    panelMediator.ShowNotifyPanel("有队友离队",1f);
                    if (mainPack.TeammatePack.TeammateCount == 1 && mainPack.TeammatePack.TeamMasterUid == networkMediator.playerSelfUid)
                    {
                        RequestMediator requestMediator = GameLoop.Instance.GetMediator<RequestMediator>();
                        BreakTeamRequest breakTeamRequest = (BreakTeamRequest)requestMediator.GetRequest(ActionCode.BreakTeam);
                        breakTeamRequest.SendRequest();
                    }
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("有队友离队失败",3f);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

}
