using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using SocketProtocol;

public class ClientMgr : IManager
{
    private Socket m_socket;
    private Message m_message;

    public ClientMgr(){
        Name = "ClientMgr";
        m_message = new Message();
        InitSocket();
    }

    private void InitSocket(){
        m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try{
            m_socket.Connect("127.0.0.1", 4567);
            if(m_socket.Connected) Debug.Log("Master Server Connected.");
            StartReceive();
        }catch(Exception e){
            Debug.LogWarning(e);
        }
    }

    private void OnDestroy() {
        m_message = null;
        CloseSocket();
    }

    private void CloseSocket(){
        if(m_socket.Connected && m_socket != null){
            m_socket.Close();
        }
    }

    private void StartReceive(){
        m_socket.BeginReceive(m_message.Buffer, m_message.StartIndex, m_message.Remsize, SocketFlags.None, ReceiveCallback, null);
    }

    private void ReceiveCallback(IAsyncResult iar){
        try{
            if(m_socket == null || m_socket.Connected == false) return;
            int length = m_socket.EndReceive(iar);
            if(length == 0){
                CloseSocket();
                return;
            }

            m_message.ReadBuffer(length, HandleResponse);
            StartReceive();
        }catch{

        }
    }

    private void HandleResponse(MainPack mainPack){
        //处理
    }

    public void Send(MainPack mainPack){
        m_socket.Send(Message.PackData(mainPack));
    }
}
