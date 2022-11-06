using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.Mgrs{
    public sealed class ClientMgr : IManager
    {
        private Socket tcpSocket;
        private Message message;
        bool isConnected;
        public NetworkMediator networkMediator;

        public ClientMgr(){
            Name = "ClientMgr";
            message = new Message();
        }

        public override void Init()
        {
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try{
                tcpSocket.Connect("127.0.0.1", 4567);
                if(tcpSocket.Connected) {
                    Debug.Log("Master Server Connected.");
                    isConnected = true;
                }
                StartReceive();
            }catch(Exception e){
                Debug.LogWarning(e);
                
            }

            InitUDP();

            networkMediator = GameLoop.Instance.GetMediator<NetworkMediator>();
            HotUpdateMediator hotUpdateMediator = GameLoop.Instance.GetMediator<HotUpdateMediator>();
            hotUpdateMediator.StartCheck(isConnected);
        }

        private void OnDestroy() {
            message = null;
            CloseSocket();
        }

        private void CloseSocket(){
            if(tcpSocket.Connected && tcpSocket != null){
                tcpSocket.Close();
            }
        }

        private void StartReceive(){
            // Debug.Log("开始接收");
            tcpSocket.BeginReceive(message.Buffer, message.StartIndex, message.Remsize, SocketFlags.None, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult iar){
            try{
                // Debug.Log("接收到消息");
                if(tcpSocket == null || tcpSocket.Connected == false) return;
                int length = tcpSocket.EndReceive(iar);
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

        public void TcpSend(MainPack mainPack){
            tcpSocket.Send(Message.TcpPackData(mainPack));
        }

        //UDP

        private Socket udpSocket;
        private IPEndPoint iPEndPoint;
        private EndPoint endPoint;
        private byte[] buffer = new byte[1024];
        private Thread thread;

        private void InitUDP(){
            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6678);
            endPoint = iPEndPoint;
            try{
                udpSocket.Connect(endPoint);
            }catch(Exception e){
                Debug.Log(e.Message);
                return;
            }


            Loom.RunAsync(()=>{
                thread = new Thread(ReceiveMessage);
                thread.Start();
            });
            

        }

        private void ReceiveMessage(){
            while(true){
                int length = udpSocket.ReceiveFrom(buffer, ref endPoint);
                MainPack mainPack = (MainPack) MainPack.Descriptor.Parser.ParseFrom(buffer, 0, length);

                Loom.QueueOnMainThread(()=>{
                    HandleResponse(mainPack);
                });
                
            }
        }

        public void UdpSend(MainPack mainPack){
            mainPack.Uid = networkMediator.uid;
            byte[] buffer = Message.UdpPackData(mainPack);
            udpSocket.Send(buffer, buffer.Length, SocketFlags.None);
        }
    }

}

