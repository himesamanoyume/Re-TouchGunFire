using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMediation : MonoBehaviour
{
    private string m_name = "IMediation";
    protected MediationMgr m_mediationMgr = null;
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }
    public IMediation(MediationMgr mediationMgr){
        m_mediationMgr = mediationMgr;
        m_mediationMgr.AddMediation(this);
    }

    private void OnDestroy() {
        m_mediationMgr.RemoveMediation(this);
    }
}
