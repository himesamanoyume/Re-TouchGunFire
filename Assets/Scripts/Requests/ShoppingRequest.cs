using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class ShoppingRequest : IRequest
{
    public override void Awake()
    {
        Name = "ShoppingRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.Shopping;
        base.Awake();
        
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    panelMediator.ShowNotifyPanel("消费成功",3f);
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("消费失败",3f);
                break;
                case ReturnCode.RepeatedRequest:
                    panelMediator.ShowNotifyPanel("已购买过该物品",3f);
                break;
                case ReturnCode.ReturnNone:
                    // Debug.LogError("不正常情况");
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }

    public void SendRequest( float price, int itemId, bool isDiamond = false)
    {
        MainPack mainPack = base.InitRequest();
        ShoppingPack shoppingPack = new ShoppingPack();
        shoppingPack.Uid = networkMediator.playerSelfUid;
        shoppingPack.IsDiamond = isDiamond;
        if (isDiamond)
        {
            shoppingPack.DiamondPrice = price;
        }else
        {
            shoppingPack.Price = (long)price;
        }
        shoppingPack.ItemId = itemId;
        mainPack.ShoppingPack = shoppingPack;
        base.TcpSendRequest(mainPack);
    }
}
