using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class AttackInviteRequest : IRequest
{
    public override void Awake()
    {
        Name = "AttackInviteRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.AttackInvite;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    Debug.Log("发起出击请求成功");
                    // panelMediator.ShowNotifyPanel("邀请好友入队成功",3f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("发起出击请求失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(int areaNumber){
        MainPack mainPack = base.InitRequest();
        TeammatePack teammatePack = new TeammatePack();
        teammatePack.SenderUid = networkMediator.playerSelfUid;
        teammatePack.State = 0;
        mainPack.TeammatePack = teammatePack;
        AttackAreaPack attackAreaPack = new AttackAreaPack();
        attackAreaPack.AreaNumber = areaNumber;
        mainPack.AttackAreaPack = attackAreaPack;
        base.TcpSendRequest(mainPack);
    }
}
