using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using SocketProtocol;

namespace ReTouchGunFire.Mgrs{
    public sealed class ClientMgr : IManager
    {
        private Socket socket;
        private Message message;

        public ClientMgr(){
            Name = "ClientMgr";
            message = new Message();
        }

        public override void Init()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try{
                socket.Connect("127.0.0.1", 4567);
                if(socket.Connected) Debug.Log("Master Server Connected.");
                StartReceive();
            }catch(Exception e){
                Debug.LogWarning(e);
            }
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
            socket.BeginReceive(message.Buffer, message.StartIndex, message.Remsize, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult iar){
            try{
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
        }

        public void Send(MainPack mainPack){
            socket.Send(Message.PackData(mainPack));
        }
    }

}

