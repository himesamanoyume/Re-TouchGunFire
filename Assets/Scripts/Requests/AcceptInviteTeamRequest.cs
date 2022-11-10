using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class AcceptInviteTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "AcceptInviteTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.AcceptInviteTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    Debug.Log("邀请好友入队成功");
                    // panelMediator.ShowNotifyPanel("邀请好友入队成功",3f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("邀请好友入队失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(int inviteSenderPlayerUid){
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.uid;
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.SenderUid = inviteSenderPlayerUid;
        teammatePack.TargetUid = networkMediator.uid;
        teammatePack.State = 1;
        mainPack.TeammatePack = teammatePack;
        base.TcpSendRequest(mainPack);
    }
}
