using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mgrs;

public abstract class IRequest : MonoBehaviour
{
    private string _name = "IRequest";
    public string Name{
        get{ return _name;}
        set{ _name = value;}
    }
    protected RequestCode requestCode;
    protected ActionCode actionCode;
    protected RequestMgr requestMgr;
    protected ClientMgr clientMgr;

    public ActionCode ActionCode{
        get{ return actionCode;}
    }

    public virtual void Awake() {
        requestMgr = GameLoop.Instance.gameManager.RequestMgr;
        clientMgr = GameLoop.Instance.gameManager.ClientMgr;
        requestMgr.AddRequest(this);
    }

    public virtual void OnDestroy() {
        requestMgr.RemoveRequest(this);
    }

    public abstract void OnResponse(MainPack mainPack);

    public virtual void SendRequest(MainPack mainPack){
        clientMgr.Send(mainPack);
    }
}
