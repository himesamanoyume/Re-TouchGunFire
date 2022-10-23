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
        public CanvasMediator m_canvasMediator;

        private void Start() {
            Init();
        }

        public override void Init()
        {
            m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
            m_abMediator = GameLoop.Instance.GetMediator<AbMediator>();
            m_canvasMediator =GameLoop.Instance.GetMediator<CanvasMediator>();
        }

        public delegate void AddInfoScriptDel(GameObject panel);


        private GameObject SpawnPanel(EUIPanelType eUIPanelType, EUILevel eUILevel){
            
            string eUIPanelTypeStr = eUIPanelType.ToString();
            // StartCoroutine(m_abMediator.AsyncLoadABRes("prefabs",eUIPanelType.ToString(),m_uiMgr.m_canvasMediator.GetCanvasLevel(eUILevel),eUILevel));
            return m_abMediator.SyncLoadABRes("prefabs", eUIPanelTypeStr, m_uiMgr.m_canvasMediator.GetCanvasLevel(eUILevel));
        }


        public void PushPanel(EUIPanelType eUIPanelType, EUILevel uILevel, bool isInsertToList,  AddInfoScriptDel addInfoScriptDel){
            // Debug.Log("Push " + eUIPanelType);
            if(m_uiMgr.m_panelDict.TryGetValue(eUIPanelType, out GameObject dictPanel)){
                dictPanel.transform.GetChild(0).gameObject.SetActive(true);
                if(isInsertToList){
                    m_uiMgr.InsertPanel(dictPanel);
                    EventMgr.Broadcast(GameEvents.ShowBackButtonPanelNotify);
                }
                    
            }else{
                
                GameObject uIPanel = SpawnPanel(eUIPanelType,uILevel);
                addInfoScriptDel(uIPanel);
                addInfoScriptDel = null;
                m_uiMgr.m_panelDict.Add(eUIPanelType, uIPanel);
                uIPanel.transform.SetParent(m_canvasMediator.GetCanvasLevel(uILevel));
                if(isInsertToList){
                    m_uiMgr.InsertPanel(uIPanel);
                    EventMgr.Broadcast(GameEvents.ShowBackButtonPanelNotify);
                }
            }
            
        }

        public void PopPanel(bool isDestroy){
            m_uiMgr.PopPanel(isDestroy);
        }

    }
}

