using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class UnlockItemSubPropRequest : ShopPanelBaseRequest
{
    public override void Awake()
    {
        Name = "UnlockItemSubPropRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.UnlockItemSubProp;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("解锁装备副词条成功");
                    // panelMediator.ShowNotifyPanel("解锁装备副词条成功",1f);
                    
                break;
                case ReturnCode.Fail:
                    // Debug.Log("删除好友请求失败");
                    panelMediator.ShowNotifyPanel("解锁装备副词条失败",3f);
                break;
                case ReturnCode.NotFound:
                    // Debug.Log("未找到该好友请求");
                    panelMediator.ShowNotifyPanel("未持有该装备",3f);
                break;
                case ReturnCode.RepeatedRequest:
                    // Debug.Log("未找到该好友请求");
                    panelMediator.ShowNotifyPanel("该装备副词条已全解锁",3f);
                break;
                default:
                    // Debug.LogError("不正常情况");
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }
}
