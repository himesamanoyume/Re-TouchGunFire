using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class CancelReadyAttackRequest : IRequest
{
    public override void Awake()
    {
        Name = "ReadyAttackRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.CancelReadyAttack;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("离开战斗请求成功");
                    // networkMediator.AttackLeaveCallback();
                    if (mainPack.TeammatePack.SenderUid != networkMediator.playerSelfUid)
                    {
                        networkMediator.ReadyAndCancelReadyAttackCallback(false, mainPack.TeammatePack.SenderUid);
                    }else
                    {
                        panelMediator.ShowNotifyPanel("已取消准备",1f);
                    }
                break;
                case ReturnCode.Fail:
                    if (mainPack.TeammatePack.SenderUid != networkMediator.playerSelfUid)
                    {
                        
                    }else
                    {
                        panelMediator.ShowNotifyPanel("取消准备失败",3f);
                    }
                break;
                default:
                    if (mainPack.TeammatePack.SenderUid != networkMediator.playerSelfUid)
                    {
                        
                    }else
                    {
                        panelMediator.ShowNotifyPanel("不正常情况",3f);
                    }
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
