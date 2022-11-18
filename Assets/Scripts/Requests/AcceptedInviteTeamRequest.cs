using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class AcceptedInviteTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "AcceptedInviteTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.AcceptedInviteTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().AcceptedInviteTeamCallback(mainPack.TeammatePack.TargetUid);
                    networkMediator.AcceptedInviteTeamCallback(mainPack.TeammatePack.TargetUid, mainPack.TeammatePack.TargetName);
                    Debug.Log("发送给好友的入队邀请已被接受");
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("发送给好友的入队邀请发生错误",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }
}
