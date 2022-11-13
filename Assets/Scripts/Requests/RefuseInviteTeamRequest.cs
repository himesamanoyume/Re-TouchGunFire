using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class RefuseInviteTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "RefuseInviteTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.RefuseInviteTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    Debug.Log("已拒绝好友的邀请入队请求");
                    
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("拒绝好友的邀请入队请求失败",3f);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(int senderUid){
        MainPack mainPack = base.InitRequest();
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.SenderUid = senderUid;
        teammatePack.TargetUid = networkMediator.playerSelfUid;
        teammatePack.State = 2;
        mainPack.TeammatePack = teammatePack;
        base.TcpSendRequest(mainPack);
    }

}
