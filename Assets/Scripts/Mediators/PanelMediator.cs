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

        private UIMgr uiMgr;
        public AbMediator abMediator;
        public CanvasMediator canvasMediator;

        private List<EUIPanelType> needToRemoveList = new List<EUIPanelType>();
        private List<EUIPanelType> needToMoveList = new List<EUIPanelType>();

        private void Start() {
            Init();
        }

        public override void Init()
        {
            uiMgr = GameLoop.Instance.gameManager.UIMgr;
            abMediator = GameLoop.Instance.GetMediator<AbMediator>();
            canvasMediator =GameLoop.Instance.GetMediator<CanvasMediator>();
            // EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        public delegate void AddInfoScriptDel(GameObject panel);
        

        private GameObject SpawnPanel(EUIPanelType eUIPanelType, EUILevel eUILevel){
            
            string eUIPanelTypeStr = eUIPanelType.ToString();
            // StartCoroutine(abMediator.AsyncLoadABRes("prefabs",eUIPanelType.ToString(),uiMgr.canvasMediator.GetCanvasLevel(eUILevel),eUILevel));
            return abMediator.SyncLoadABRes("prefabs", eUIPanelTypeStr, uiMgr.canvasMediator.GetCanvasLevel(eUILevel));
        }

        public void MovePanelLevelUp(){

        }

        public void PushPanel(EUIPanelType eUIPanelType, EUILevel uILevel, bool isInsertToList, EUIRestoreType eUIRestoreType, AddInfoScriptDel addInfoScriptDel){
            // Debug.Log("Push " + eUIPanelType);
            if(uiMgr.panelDict.TryGetValue(eUIPanelType, out GameObject dictPanel)){
                dictPanel.transform.GetChild(0).gameObject.SetActive(true);
                if(isInsertToList){
                    uiMgr.InsertPanel(dictPanel);
                    EventMgr.Broadcast(GameEvents.ShowBackButtonPanelNotify);
                }
                    
            }else{
                
                GameObject uIPanel = SpawnPanel(eUIPanelType,uILevel);
                addInfoScriptDel(uIPanel);
                addInfoScriptDel = null;
                uiMgr.panelDict.Add(eUIPanelType, uIPanel);
                uIPanel.transform.SetParent(canvasMediator.GetCanvasLevel(uILevel));
                if(isInsertToList){
                    uiMgr.InsertPanel(uIPanel);
                    EventMgr.Broadcast(GameEvents.ShowBackButtonPanelNotify);
                }
            }

            // switch(eUIRestoreType){
            //     case EUIRestoreType.Null:
                    
            //     break;
            //     case EUIRestoreType.RemovePanelType:
            //         needToRemoveList.Add(eUIPanelType);
            //     break;
            //     case EUIRestoreType.MovePanelType:
            //         needToMoveList.Add(eUIPanelType);
            //     break;
            // }
                
            
        }

        public void PopPanel(bool isDestroy){
            uiMgr.PopPanel(isDestroy);
        }

        /// <summary>
        /// 如果PanelList内没有面板了则返回true
        /// </summary>
        /// <returns></returns>
        public bool CheckPanelList(){
            return uiMgr.CheckPanelList();
        }

        public void MovePanelLevel(EUIPanelType eUIPanelType, EUILevel eUILevel){
            uiMgr.MovePanelLevel(eUIPanelType, eUILevel);
        }

        public void RemovePanel(EUIPanelType eUIPanelType){
            if(uiMgr.panelDict.TryGetValue(eUIPanelType, out GameObject panel)){
                Destroy(panel);
                uiMgr.panelDict.Remove(eUIPanelType);
            }
        }
    }
}

