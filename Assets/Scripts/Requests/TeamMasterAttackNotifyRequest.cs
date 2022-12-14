using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class TeamMasterAttackNotifyRequest : IRequest
{
    public override void Awake()
    {
        Name = "TeamMasterAttackNotifyRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.TeamMasterAttackNotify;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("离开战斗请求成功");
                    // networkMediator.AttackLeaveCallback();
                    if (networkMediator.teamMasterPlayerUid != mainPack.TeammatePack.TeamMasterUid)
                    {
                        panelMediator.ShowNotifyPanel("小队长通知队员尽快准备",5f);
                    }
                break;
                case ReturnCode.Fail:
                    if (networkMediator.teamMasterPlayerUid == mainPack.TeammatePack.TeamMasterUid)
                    {
                        panelMediator.ShowNotifyPanel("提醒队员通知失败",3f);
                    } 
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(){
        MainPack mainPack = base.InitRequest();
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.SenderUid = networkMediator.playerSelfUid;
        teammatePack.TeamMasterUid = networkMediator.teamMasterPlayerUid;
        mainPack.TeammatePack = teammatePack;
        base.TcpSendRequest(mainPack);
    }
}
