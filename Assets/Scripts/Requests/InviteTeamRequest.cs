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
                    panelMediator.ShowNotifyPanel("邀请好友入队失败",3f);
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
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.uid;
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.SenderUid = networkMediator.uid;
        teammatePack.TargetUid = targetPlayerUid;
        teammatePack.State = 0;
        mainPack.TeammatePack = teammatePack;
        base.TcpSendRequest(mainPack);
    }
}
