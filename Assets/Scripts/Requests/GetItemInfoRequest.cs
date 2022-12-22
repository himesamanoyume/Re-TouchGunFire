// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using SocketProtocol;
// using ReTouchGunFire.Mediators;
// using ReTouchGunFire.PanelInfo;

// public sealed class GetItemInfoRequest : IRequest
// {
//     public override void Awake()
//     {
//         Name = "GetItemInfoRequest";
//         requestCode = RequestCode.User;
//         actionCode = ActionCode.GetItemInfo;
//         base.Awake();
        
//     }

//     public override void OnResponse(MainPack mainPack)
//     {
//         Loom.QueueOnMainThread(()=>{
//             switch(mainPack.ReturnCode){
//                 case ReturnCode.Success:
//                     // Debug.Log("物品信息获取成功");
//                     networkMediator.UpdatePlayerGunInfoCallback(mainPack.PlayerInfoPack.GunPacks);
//                     networkMediator.UpdatePlayerEquipmentInfoCallback(mainPack.PlayerInfoPack.EquipmentPacks);
//                 break;
//                 case ReturnCode.Fail:
//                     panelMediator.ShowNotifyPanel("物品信息获取失败",3f);
//                 break;
//                 case ReturnCode.ReturnNone:
//                     // Debug.LogError("不正常情况");
//                     panelMediator.ShowNotifyPanel("不正常情况",3f);
//                 break;
//             }
//         });
//     }
// }
