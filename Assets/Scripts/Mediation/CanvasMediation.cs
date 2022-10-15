using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMediation : IMediation
{
    public UIMgr m_uiMgr = null;
    
    public CanvasMediation(){
        Name = "CanvasMediation";
        m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
    }
}
