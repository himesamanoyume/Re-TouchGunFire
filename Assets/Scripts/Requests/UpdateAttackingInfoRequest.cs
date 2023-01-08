using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class UpdateAttackingInfoRequest : IRequest
{
    public override void Awake()
    {
        Name = "UpdateAttackingInfoRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.UpdateAttackingInfo;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("更新战斗");
                    networkMediator.UpdateAttackingInfoCallback(mainPack.AttackAreaPack.EnemyPack);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("离开战斗请求失败",3f);
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
