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
        public PanelMediator panelMediator;

        public int playerSelfUid = 0;
        public int teamMasterPlayerUid = 0;

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
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
        }

        public void TcpSend(MainPack mainPack){
            clientMgr.TcpSend(mainPack);
        }

        public void UdpSend(MainPack mainPack){
            clientMgr.UdpSend(mainPack);
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

        public void OnUserLoginSuccess(){
            Loom.QueueOnMainThread(()=>{
                panelMediator.ShowNotifyPanel("登陆成功",2f);
                EventMgr.Broadcast(GameEvents.UserLoginSuccessNotify);
            });
        }

        public void OnUserLoginFail(){
            Loom.QueueOnMainThread(()=>{
                panelMediator.ShowNotifyPanel("登陆失败~请检查账号密码是否输入正确",2f);
            });
        }

        public void OnUserRegisterSuccess(){
            Loom.QueueOnMainThread(()=>{
                panelMediator.ShowNotifyPanel("注册成功",2f);
            });
        }

        public void OnUserRegisterFail(){
            Loom.QueueOnMainThread(()=>{
                panelMediator.ShowNotifyPanel("注册失败~可能账号已被注册",2f);
            });
        }
        
    }
}

