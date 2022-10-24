using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mgrs;


namespace ReTouchGunFire.Mediators{
    public sealed class NetworkMediator : IMediator
    {
        public ClientMgr clientMgr;
        public RequestMgr requestMgr;
        public NetworkMediator(){
            Name = "NetworkMediator";
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            clientMgr = GameLoop.Instance.gameManager.ClientMgr;
            requestMgr = GameLoop.Instance.gameManager.RequestMgr;
        }

        public void Send(MainPack mainPack){
            clientMgr.Send(mainPack);
        }

        public void AddRequest(IRequest request)
        {
            requestMgr.AddRequest(request);
        }

        public void RemoveRequest(IRequest request)
        {
            requestMgr.RemoveRequest(request);
        }

        public void HandleResponse(MainPack mainPack){
            requestMgr.HandleResponse(mainPack);
        }
    }
}

