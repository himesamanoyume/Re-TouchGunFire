using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class RefusedInviteTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "RefusedInviteTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.RefusedInviteTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    panelMediator.ShowNotifyPanel("对方拒绝了你的请求",3f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("对方拒绝邀请失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

}
