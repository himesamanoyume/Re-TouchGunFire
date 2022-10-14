using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public sealed class NetworkMediation : IMediation
{
    private ClientMgr m_clientMgr = null;
    private RequestMgr m_requestMgr = null;
    private MediationMgr m_mediationMgr = null;
    public NetworkMediation(){
        Name = "NetworkMediation";
        m_clientMgr = GameManager.Instance.ClientMgr;
        m_requestMgr = GameManager.Instance.RequestMgr;
        m_mediationMgr = GameManager.Instance.MediationMgr;
        m_mediationMgr.AddMediation(this);
    }

    private void OnDestroy() {
        m_mediationMgr.RemoveMediation(this);
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
