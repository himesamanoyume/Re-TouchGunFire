using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ReTouchGunFire.Mgrs;
using ReTouchGunFire.PanelInfo;


namespace ReTouchGunFire.Mediators{
    public class PanelMediator : IMediator
    {
        public PanelMediator(){
            Name = "PanelMediator";
        }

        private UIMgr m_uiMgr;
        public AbMediator m_abMediator;

        private void Start() {
            Init();
        }

        public override void Init()
        {
            m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
            m_abMediator = GameLoop.Instance.GetMediator<AbMediator>();
        }

        public delegate void AddInfoScriptDel(GameObject panel);

        public void SpawnPanel(EUIPanelType eUIPanelType, EUILevel eUILevel, AddInfoScriptDel addInfoScriptDel){
            
            string eUIPanelTypeStr = eUIPanelType.ToString();
            // StartCoroutine(m_abMediator.AsyncLoadABRes("prefabs",eUIPanelType.ToString(),m_uiMgr.m_canvasMediator.GetCanvasLevel(eUILevel),eUILevel));
            GameObject panel = m_abMediator.SyncLoadABRes("prefabs", eUIPanelTypeStr, m_uiMgr.m_canvasMediator.GetCanvasLevel(eUILevel), eUILevel);
            addInfoScriptDel(panel);
            addInfoScriptDel = null;
        }

        public void SpawnBackButtonPanel(){
            GameObject backButtonPanel = m_abMediator.SyncLoadABRes("prefabs", EUIPanelType.BackButtonPanel.ToString(), m_uiMgr.m_canvasMediator.GetCanvasLevel(EUILevel.Level4));
            backButtonPanel.AddComponent<BackButtonPanelInfo>();
        }

        public void PopPanel(){
            m_uiMgr.PopPanel();
        }

    }
}

