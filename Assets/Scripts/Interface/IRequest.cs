using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public abstract class IRequest : MonoBehaviour
{
    private string m_name = "IRequest";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }
    protected RequestCode m_requestCode;
    protected ActionCode m_actionCode;
    protected RequestMgr m_requestMgr;
    protected ClientMgr m_clientMgr;

    public ActionCode ActionCode{
        get{ return m_actionCode;}
    }

    public virtual void Awake() {
        m_requestMgr = GameManager.Instance.RequestMgr;
        m_clientMgr = GameManager.Instance.ClientMgr;
        m_requestMgr.AddRequest(this);
    }

    public virtual void OnDestroy() {
        m_requestMgr.RemoveRequest(this);
    }

    public abstract void OnResponse(MainPack mainPack);

    public virtual void SendRequest(MainPack mainPack){
        m_clientMgr.Send(mainPack);
    }
}
