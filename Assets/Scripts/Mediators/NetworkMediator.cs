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

        public int uid = 0;

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

        public void OnUserLoginSuccess(){
            isNeedShowUserLoginSuccess = true;
        }

        public void OnUserLoginFail(){
            isNeedShowUserLoginFail = true;
        }

        public void OnUserRegisterSuccess(){
            isNeedShowUserRegisterSuccess = true;
        }

        public void OnUserRegisterFail(){
            isNeedShowUserRegisterFail = true;
        }

        bool isNeedShowUserLoginSuccess = false;
        bool isNeedShowUserLoginFail = false;
        bool isNeedShowUserRegisterSuccess = false;
        bool isNeedShowUserRegisterFail = false;

        private void Update() {
            if(isNeedShowUserLoginSuccess){
                isNeedShowUserLoginSuccess = false;
                panelMediator.ShowNotifyPanel("登陆成功",2f);
                EventMgr.Broadcast(GameEvents.UserLoginSuccessNotify);
            }
            if(isNeedShowUserLoginFail){
                isNeedShowUserLoginFail = false;
                panelMediator.ShowNotifyPanel("登陆失败~",2f);
            }
            if(isNeedShowUserRegisterSuccess){
                isNeedShowUserRegisterSuccess = false;
                panelMediator.ShowNotifyPanel("注册成功",2f);
            }
            if(isNeedShowUserRegisterFail){
                isNeedShowUserRegisterFail = false;
                panelMediator.ShowNotifyPanel("注册失败~",2f);
            }

        }

        
    }
}

