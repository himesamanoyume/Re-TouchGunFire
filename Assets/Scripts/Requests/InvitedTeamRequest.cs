using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class InvitedTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "InvitedTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.InvitedTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    // panelMediator.ShowNotifyPanel("接收好友邀请入队成功",3f);
                    // panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().InvitedTeamCallback(mainPack.TeammatePack.SenderUid);
                    networkMediator.InvitedTeamCallback(mainPack.TeammatePack.SenderUid, mainPack.TeammatePack.SenderName);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("接收好友邀请入队失败",3f);
                break;
                case ReturnCode.RepeatedRequest:
                    panelMediator.ShowNotifyPanel("好友已有队伍",3f);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

}
