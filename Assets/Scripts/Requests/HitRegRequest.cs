using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class HitRegRequest : IRequest
{
    public override void Awake()
    {
        Name = "HitRegRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.HitReg;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    
                break;
                case ReturnCode.Fail:
                    // panelMediator.ShowNotifyPanel("获取队伍信息失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(){
        MainPack mainPack = base.InitRequest();
        base.UdpSendRequest(mainPack);
    }

}
