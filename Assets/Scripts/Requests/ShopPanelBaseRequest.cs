// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using SocketProtocol;
// using ReTouchGunFire.PanelInfo;
// using System;

// public abstract class ShopPanelBaseRequest : IRequest
// {
//     public virtual void SendRequest(float price, int itemId, float per = 1, bool isDiamond = false){
//         MainPack mainPack = base.InitRequest();
//         ShoppingPack shoppingPack = new ShoppingPack();
//         shoppingPack.Uid = networkMediator.playerSelfUid;
//         shoppingPack.IsDiamond = isDiamond;
//         if (isDiamond)
//         {
//             shoppingPack.DiamondPrice = (float)Math.Round((double)(price * per), 3);
//         }else
//         {
//             shoppingPack.Price = (float)Math.Round((double)(price * per), 3);
//         }
//         shoppingPack.Percent = per;
//         shoppingPack.ItemId = itemId;
//         mainPack.ShoppingPack = shoppingPack;
//         base.TcpSendRequest(mainPack);
//     }
// }
