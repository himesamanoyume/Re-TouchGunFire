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
                    // Debug.Log("接受好友的入队邀请成功");
                    // panelMediator.ShowNotifyPanel("邀请好友入队成功",3f);
                    panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().AcceptedInviteTeamCallback();
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
}
