using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class RefusedJoinTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "RefusedJoinTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.RefusedJoinTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    panelMediator.ShowNotifyPanel("申请加入小队被拒绝",3f);
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

    // public void SendRequest(int targetPlayerUid){
    //     MainPack mainPack = base.InitRequest();
    //     TeammatePack teammatePack = new TeammatePack();
    //     teammatePack.JoinTeamPlayerUid = networkMediator.playerSelfUid;
    //     teammatePack.TeamMemberUid = targetPlayerUid;
    //     teammatePack.State = 2;
    //     mainPack.TeammatePack = teammatePack;

    //     base.TcpSendRequest(mainPack);
    // }

}
