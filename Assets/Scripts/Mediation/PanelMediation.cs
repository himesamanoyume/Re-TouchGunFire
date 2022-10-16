using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMediation : IMediation
{
    public PanelMediation(){
        Name = "PanelMediation";
    }

    public UIMgr m_uiMgr = null;
    public AbMediation m_abMediation = null;

    public override void Init()
    {
        m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
        if(GameLoop.Instance.TryGetComponent<AbMediation>(out AbMediation abMediation)){
            m_abMediation = abMediation;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }  
    }

    public void SpawnPanel(EUIPanelType eUIPanelType, EUILevel eUILevel){
        StartCoroutine(m_abMediation.AsyncLoadABUIRes("prefabs",eUIPanelType.ToString(),m_uiMgr.m_canvasMediation.GetCanvasLevel(EUILevel.Level2),eUILevel));
    }

}
