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
                    panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().AcceptInviteTeamCallback(mainPack.TeammatePack.SenderUid);
                    
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("接受好友的入队邀请失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(int inviteSenderPlayerUid){
        MainPack mainPack = base.InitRequest();
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.SenderUid = inviteSenderPlayerUid;
        teammatePack.TargetUid = networkMediator.playerSelfUid;
        teammatePack.State = 1;
        mainPack.TeammatePack = teammatePack;
        base.TcpSendRequest(mainPack);
    }
}
