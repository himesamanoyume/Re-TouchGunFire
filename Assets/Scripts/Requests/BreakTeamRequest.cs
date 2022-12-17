using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class BreakTeamRequest : IRequest
{
    public override void Awake()
    {
        Name = "BreakTeamRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.BreakTeam;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("已自动解散离队");
                    panelMediator.ShowNotifyPanel("已自动解散离队",1f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("解散队伍失败",3f);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(){
        MainPack mainPack = base.InitRequest();
        // Debug.Log("发送解散队伍请求");
        base.TcpSendRequest(mainPack);
    }

}
