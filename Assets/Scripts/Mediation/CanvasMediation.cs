using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMediation : IMediation
{
    public UIMgr m_uiMgr = null;
    public AbMediation m_abMediation = null;
    public GameObject m_canvas = null;
    
    public CanvasMediation(){
        Name = "CanvasMediation";  
    }

    public override void Init()
    {
        m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
    }

    public void InitCanvas(){

        if(GameLoop.Instance.TryGetComponent<AbMediation>(out AbMediation abMediation)){
            m_abMediation = abMediation;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }   
        m_canvas = m_abMediation.SyncLoadABRes("prefabs", "Canvas", null);
        m_canvas.name = "Canvas";
        // Debug.Log(canvas.name);
        m_canvas.AddComponent<CanvasInfo>().InitCanvasChild();
    }

    public Transform GetCanvasLevel(EUILevel eUILevel){
        switch(eUILevel){
            case EUILevel.Level1:
                return m_canvas.GetComponent<CanvasInfo>().Level1;
            case EUILevel.Level2:
                return m_canvas.GetComponent<CanvasInfo>().Level2;
            case EUILevel.Level3:
                return m_canvas.GetComponent<CanvasInfo>().Level3;
            case EUILevel.Level4:
                return m_canvas.GetComponent<CanvasInfo>().Level4;
        }
        return null;
    }
}
