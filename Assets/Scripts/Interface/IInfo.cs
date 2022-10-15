using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInfo : IBase
{
    protected InfoMgr m_infoMgr;

    public virtual void Awake(){
        // m_infoMgr = GameManager.Instance.InfoMgr;
        m_infoMgr = GameLoop.Instance.gameManager.InfoMgr;
    }
}
