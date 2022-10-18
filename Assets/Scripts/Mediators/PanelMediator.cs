using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;


namespace ReTouchGunFire.Mediators{
    public class PanelMediator : IMediator
    {
        public PanelMediator(){
            Name = "PanelMediator";
        }

        public UIMgr m_uiMgr = null;
        public AbMediator m_abMediator = null;

        public override void Init()
        {
            m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
            if(GameLoop.Instance.TryGetComponent<AbMediator>(out AbMediator abMediator)){
                m_abMediator = abMediator;
            }else{
                Debug.LogWarning("未拿到对应组件");
            }  
        }

        public void SpawnPanel(EUIPanelType eUIPanelType, EUILevel eUILevel){
            StartCoroutine(m_abMediator.AsyncLoadABUIRes("prefabs",eUIPanelType.ToString(),m_uiMgr.m_canvasMediator.GetCanvasLevel(EUILevel.Level2),eUILevel));
        }

    }
}
