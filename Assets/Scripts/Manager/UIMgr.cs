using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UIMgr : IManager
{
    public CanvasMediation m_canvasMediation = null;
    private List<GameObject> m_PanelList = new List<GameObject>();
    public UIMgr(){
        Name = "UIMgr";
    }

    public override void Init(){
        if(GameLoop.Instance.TryGetComponent<CanvasMediation>(out CanvasMediation canvasMediation)){
            m_canvasMediation = canvasMediation;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }  
        // m_canvas = m_canvasMediation.m_canvas;
    }

    public void PushPanel(EUILevel uILevel, GameObject uIPanel){
        m_PanelList.Add(uIPanel);
        uIPanel.transform.SetParent(m_canvasMediation.GetCanvasLevel(uILevel));
    }

    public void SpawnPanel(EUIPanelType uIPanelType, EUILevel uILevel){
        
    }

    public void PopPanel(){
        GameObject.Destroy(m_PanelList[0]);
        m_PanelList.Remove(m_PanelList[0]);
    }



}
