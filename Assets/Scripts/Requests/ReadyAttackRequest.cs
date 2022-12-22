// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using SocketProtocol;
// using ReTouchGunFire.PanelInfo;

// public sealed class ReadyAttackRequest : IRequest
// {
//     public override void Awake()
//     {
//         Name = "ReadyAttackRequest";
//         requestCode = RequestCode.Gaming;
//         actionCode = ActionCode.ReadyAttack;
//         base.Awake();
//     }

//     public override void OnResponse(MainPack mainPack)
//     {
//         Loom.QueueOnMainThread(()=>{
//             switch(mainPack.ReturnCode){
//                 case ReturnCode.Success:
//                     // Debug.Log("离开战斗请求成功");
//                     // networkMediator.AttackLeaveCallback();
//                     if (networkMediator.playerSelfUid != mainPack.TeammatePack.SenderUid)
//                     {
//                         networkMediator.ReadyAndCancelReadyAttackCallback(true, mainPack.TeammatePack.SenderUid);
//                     }else
//                     {
//                         panelMediator.ShowNotifyPanel("已准备",1f);
//                         networkMediator.ReadyAttackCallback();
//                     }
//                 break;
//                 case ReturnCode.Fail:
//                     if (networkMediator.playerSelfUid != mainPack.TeammatePack.SenderUid)
//                     {
                        
//                     }else
//                     {
//                         panelMediator.ShowNotifyPanel("准备就绪 失败",3f);
//                     }
//                 break;
//                 default:
//                     if (networkMediator.playerSelfUid != mainPack.TeammatePack.SenderUid)
//                     {
                        
//                     }else
//                     {
//                         panelMediator.ShowNotifyPanel("不正常情况",3f);
//                     } 
//                 break;
            
//             }
//         });
//     }

//     public void SendRequest(){
//         MainPack mainPack = base.InitRequest();
//         TeammatePack teammatePack = new TeammatePack();
//         teammatePack.SenderUid = networkMediator.playerSelfUid;
//         teammatePack.TeamMasterUid = networkMediator.teamMasterPlayerUid;
//         mainPack.TeammatePack = teammatePack;
//         base.TcpSendRequest(mainPack);
//     }
// }
