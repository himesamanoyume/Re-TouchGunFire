// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using ReTouchGunFire.Mgrs;
// using SocketProtocol;

// namespace ReTouchGunFire.Mediators{

//     public class RequestMediator : IMediator
//     {
//         public RequestMediator()
//         {
//             Name = "RequestMediator";
//         }

//         private RequestMgr requestMgr;

//         private void Start() {
//             Init();
//         }

//         public override void Init()
//         {
//             requestMgr = GameLoop.Instance.gameManager.RequestMgr;
//         }

//         public IRequest GetRequest(ActionCode actionCode){
//             return requestMgr.GetRequest(actionCode);
//         }
//     }
// }

