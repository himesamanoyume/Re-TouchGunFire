using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class EquipItemRequest : IRequest
{
    public override void Awake()
    {
        Name = "EquipItemRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.EquipItem;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    Debug.Log("穿戴装备成功");
                    EventMgr.Broadcast(GameEvents.PlayerMainGunUpdateNotify);
                    EventMgr.Broadcast(GameEvents.PlayerHandGunUpdateNotify);
                    // panelMediator.ShowNotifyPanel("删除好友请求成功",3f);
                    
                break;
                case ReturnCode.Fail:
                    // Debug.Log("删除好友请求失败");
                    panelMediator.ShowNotifyPanel("穿戴装备失败",3f);
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
