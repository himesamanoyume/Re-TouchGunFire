using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public class IRequest : MonoBehaviour
{
    protected RequestCode m_requestCode;
    protected ActionCode m_actionCode;

    public ActionCode ActionCode{
        get{ return m_actionCode;}
    }

    public virtual void Awake() {
        GameLoop.Instance.GameManager.RequestMgr.AddRequest(this);
    }

    public virtual void OnDestroy() {
        GameLoop.Instance.GameManager.RequestMgr.RemoveRequest(this);
    }

    public virtual void OnResponse(MainPack mainPack){

    }

    public virtual void SendRequest(MainPack mainPack){
        GameLoop.Instance.GameManager.ClientMgr.Send(mainPack);
    }
}
