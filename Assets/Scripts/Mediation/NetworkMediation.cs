using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public sealed class NetworkMediation : IMediation
{
    public ClientMgr m_clientMgr = null;
    public RequestMgr m_requestMgr = null;
    public NetworkMediation(){
        Name = "NetworkMediation";
        m_clientMgr = GameLoop.Instance.gameManager.ClientMgr;
        m_requestMgr = GameLoop.Instance.gameManager.RequestMgr;
    }

    public void Send(MainPack mainPack){
        m_clientMgr.Send(mainPack);
    }

    public void AddRequest(IRequest request)
    {
        m_requestMgr.AddRequest(request);
    }

    public void RemoveRequest(IRequest request)
    {
        m_requestMgr.RemoveRequest(request);
    }

    public void HandleResponse(MainPack mainPack){
        m_requestMgr.HandleResponse(mainPack);
    }
}
