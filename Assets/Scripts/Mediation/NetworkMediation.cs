using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public sealed class NetworkMediation : IMediation
{
    private ClientMgr m_clientMgr = null;
    private RequestMgr m_requestMgr = null;
    public NetworkMediation(MediationMgr mediationMgr) : base(mediationMgr){
        Name = "NetworkMediation";
        m_clientMgr = GameManager.Instance.ClientMgr;
        m_requestMgr = GameManager.Instance.RequestMgr;
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
