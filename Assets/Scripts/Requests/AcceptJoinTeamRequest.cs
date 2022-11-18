using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class AcceptJoinTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "AcceptJoinTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.AcceptJoinTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    Debug.Log("AcceptJoinTeamRequest Success");
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(int targetPlayerUid){
        MainPack mainPack = base.InitRequest();
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.JoinTeamPlayerUid = targetPlayerUid;
        teammatePack.TeamMemberUid = networkMediator.playerSelfUid;
        teammatePack.State = 1;
        mainPack.TeammatePack = teammatePack;

        base.TcpSendRequest(mainPack);
    }

}
