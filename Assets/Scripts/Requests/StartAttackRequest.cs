using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class StartAttackRequest : IRequest
{
    public override void Awake()
    {
        Name = "StartAttackRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.StartAttack;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("发起出击请求成功");
                    panelMediator.ShowNotifyPanel("正在前往地区1",3f);
                    networkMediator.StartAttackCallback(mainPack.AttackAreaPack.AreaNumber);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("开始出击失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }
}
