using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UIMgr : IManager
{
    private Dictionary<EUIPanelType, UIInfo> m_uiPanelDict = new Dictionary<EUIPanelType, UIInfo>();
    private Dictionary<EUIPanelType, string> m_uiPanelPathDict = new Dictionary<EUIPanelType, string>();
    public GameObject m_canvasPrefab = null;
    public UIMgr(){
        Name = "UIMgr";
        //ab加载CanvasPrefab

        //end
        m_canvasPrefab.AddComponent<CanvasInfo>();
    }

    private void PushPanel(EUIPanelType uIPanelType, EUILevel uILevel){

    }

    private void SpawnPanel(EUIPanelType uIPanelType, EUILevel uILevel){

    }

    private void SetPanel(){

    }
}
