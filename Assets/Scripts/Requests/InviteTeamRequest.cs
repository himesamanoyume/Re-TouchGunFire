using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class InviteTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "InviteTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.InviteTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    panelMediator.ShowNotifyPanel("邀请好友入队成功",3f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("邀请好友入队失败,对方或已有队伍",3f);
                break;
                case ReturnCode.RepeatedRequest:
                    panelMediator.ShowNotifyPanel("好友不在线",3f);
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
        teammatePack.SenderUid = networkMediator.playerSelfUid;
        teammatePack.TargetUid = targetPlayerUid;
        teammatePack.State = 0;
        mainPack.TeammatePack = teammatePack;
        base.TcpSendRequest(mainPack);
    }
}
