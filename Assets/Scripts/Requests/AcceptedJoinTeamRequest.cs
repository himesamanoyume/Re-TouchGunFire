// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using SocketProtocol;
// using ReTouchGunFire.PanelInfo;

// public sealed class AcceptedJoinTeamRequest : IRequest
// {
//     public override void Awake()
//     {
//         Name = "AcceptedJoinTeamRequest";
//         requestCode = RequestCode.Team;
//         actionCode = ActionCode.AcceptedJoinTeam;
//         base.Awake();
//     }

//     public override void OnResponse(MainPack mainPack)
//     {
//         Loom.QueueOnMainThread(()=>{
//             switch(mainPack.ReturnCode){
//                 case ReturnCode.Success:
//                     //右下角显示有人拉我
//                     // Debug.Log("AcceptedJoinTeamRequest Success");
//                 break;
//                 case ReturnCode.Fail:
//                     panelMediator.ShowNotifyPanel("失败",3f);
//                 break;
//                 default:
//                     panelMediator.ShowNotifyPanel("不正常情况",3f);
//                 break;
            
//             }
//         });
//     }
// }
