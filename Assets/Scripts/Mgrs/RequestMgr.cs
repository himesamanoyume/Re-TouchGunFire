using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

namespace ReTouchGunFire.Mgrs{
    public sealed class RequestMgr : IManager
    {
        public RequestMgr(){
            Name = "RequestMgr";
        }

        public override void Init(){
            
        }

        private Dictionary<ActionCode, IRequest> requestDict = new Dictionary<ActionCode, IRequest>();

        public void AddRequest(IRequest request){
            requestDict.Add(request.ActionCode, request);
        }

        public void RemoveRequest(IRequest request){
            requestDict.Remove(request.ActionCode);
        }

        public void HandleResponse(MainPack mainPack){
            if(requestDict.TryGetValue(mainPack.ActionCode, out IRequest request)){
                request.OnResponse(mainPack);
            }else{
                Debug.LogWarning(mainPack.ActionCode+" 找不到对应的处理.");
            }
        }
    }

}

