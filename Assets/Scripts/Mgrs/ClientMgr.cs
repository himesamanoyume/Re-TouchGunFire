using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.Mgrs{
    public sealed class ClientMgr : IManager
    {
        private Socket socket;
        private Message message;
        bool isConnected;
        public NetworkMediator networkMediator;

        public ClientMgr(){
            Name = "ClientMgr";
            message = new Message();
        }

        public override void Init()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try{
                socket.Connect("127.0.0.1", 4567);
                if(socket.Connected) {
                    Debug.Log("Master Server Connected.");
                    isConnected = true;
                }
                StartReceive();
            }catch(Exception e){
                Debug.LogWarning(e);
                
            }
            networkMediator = GameLoop.Instance.GetMediator<NetworkMediator>();
            HotUpdateMediator hotUpdateMediator = GameLoop.Instance.GetMediator<HotUpdateMediator>();
            hotUpdateMediator.StartCheck(isConnected);
        }

        private void OnDestroy() {
            message = null;
            CloseSocket();
        }

        private void CloseSocket(){
            if(socket.Connected && socket != null){
                socket.Close();
            }
        }

        private void StartReceive(){
            // Debug.Log("开始接收");
            socket.BeginReceive(message.Buffer, message.StartIndex, message.Remsize, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult iar){
            try{
                // Debug.Log("接收到消息");
                if(socket == null || socket.Connected == false) return;
                int length = socket.EndReceive(iar);
                if(length == 0){
                    CloseSocket();
                    return;
                }

                message.ReadBuffer(length, HandleResponse);
                StartReceive();
            }catch{

            }
        }

        private void HandleResponse(MainPack mainPack){
            //处理
            networkMediator.HandleResponse(mainPack);
        }

        public void Send(MainPack mainPack){
            socket.Send(Message.PackData(mainPack));
        }
    }

}

