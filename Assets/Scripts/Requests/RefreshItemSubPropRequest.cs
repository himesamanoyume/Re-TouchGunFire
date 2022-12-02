using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class RefreshItemSubPropRequestRequest : IRequest
{
    public override void Awake()
    {
        Name = "RefreshItemSubPropRequestRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.RefreshItemSubProp;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("穿戴装备成功");
                    panelMediator.ShowNotifyPanel("刷新装备副词条成功",1f);
                    
                break;
                case ReturnCode.Fail:
                    // Debug.Log("删除好友请求失败");
                    panelMediator.ShowNotifyPanel("刷新装备副词条失败",3f);
                break;
                case ReturnCode.NotFound:
                    // Debug.Log("未找到该好友请求");
                    panelMediator.ShowNotifyPanel("未持有该装备",3f);
                break;
                default:
                    // Debug.LogError("不正常情况");
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }

    public void SendRequest(int itemId){
        MainPack mainPack = base.InitRequest();
        EquipItemPack equipItemPack = new EquipItemPack();
        equipItemPack.Uid = networkMediator.playerSelfUid;
        equipItemPack.ItemId = itemId;
        mainPack.EquipItemPack = equipItemPack;
        base.TcpSendRequest(mainPack);
    }
}
