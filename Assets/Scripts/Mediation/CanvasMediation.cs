using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMediation : IMediation
{
    private UIMgr m_uiMgr = null;
    
    public CanvasMediation(MediationMgr mediationMgr) : base(mediationMgr){
        Name = "CanvasMediation";
        m_uiMgr = GameManager.Instance.UIMgr;
    }
}
