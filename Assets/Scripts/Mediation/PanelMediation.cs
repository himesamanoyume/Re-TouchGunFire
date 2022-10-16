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

    public void SpawnInitPanel(){
        GameObject initPanel = m_abMediation.SyncLoadABRes("prefabs","InitPanel",m_uiMgr.m_canvasMediation.GetCanvasLevel(EUILevel.Level2));
        initPanel.name = "InitPanel";
        m_uiMgr.PushPanel(EUILevel.Level2,initPanel);
    }
}
