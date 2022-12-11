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

        public GameObject GetPanel(EUIPanelType eUIPanelType){
            if (uiMgr.panelDict.TryGetValue(eUIPanelType, out GameObject panel))
            {
                return panel;
            }else{
                return null;
            }
        }

        public delegate void AddInfoScriptDel(GameObject panel);

        private void SpawnPanel(EUIPanelType eUIPanelType, EUILevel eUILevel, bool isInsertToList, AddInfoScriptDel addInfoScriptDel){
            
            string eUIPanelTypeStr = eUIPanelType.ToString();

            StartCoroutine(abMediator.AsyncLoadABRes(
            eUIPanelTypeStr,
            uiMgr.canvasMediator.GetCanvasLevel(eUILevel),
            eUIPanelType,
            eUILevel,
            isInsertToList, 
            addInfoScriptDel
            ));
        }

        public void LoadResFromAbMediatorCallback(GameObject uIPanel, EUIPanelType eUIPanelType, EUILevel eUILevel, bool isInsertToList,AddInfoScriptDel addInfoScriptDel ){
            addInfoScriptDel(uIPanel);
            addInfoScriptDel = null;
            uiMgr.panelDict.Add(eUIPanelType, uIPanel);
            uIPanel.transform.SetParent(canvasMediator.GetCanvasLevel(eUILevel));
            if(isInsertToList){
                uiMgr.InsertPanel(uIPanel);
                EventMgr.Broadcast(GameEvents.ShowBackButtonPanelNotify);
            }
        }

        public EUILevel GetPanelLevelUp(EUILevel currentUILevel){
            
            switch(currentUILevel){
                case EUILevel.Level1:
                    return EUILevel.Level2;
                case EUILevel.Level2:
                    return EUILevel.Level3;
                case EUILevel.Level3:
                    return EUILevel.Level4;
                case EUILevel.Level4:
                    return EUILevel.Level5;
                case EUILevel.Level5:
                    return EUILevel.Level6;
                case EUILevel.Level6:
                    return EUILevel.Level6;
            }
            return EUILevel.Level1;
        }

        public void ShowTwiceConfirmPanel(string text, float countdown, Action action){
            GetPanel(EUIPanelType.TwiceConfirmPanel).GetComponent<TwiceConfirmPanelInfo>().ShowTwiceConfirmPanel(text, countdown, action);
        }

        public void PushPanel(EUIPanelType eUIPanelType, EUILevel uILevel, bool isInsertToList, AddInfoScriptDel addInfoScriptDel){
            
            //如果已有该面板 则直接拿去并将其移动至目标参数的level
            if(uiMgr.panelDict.TryGetValue(eUIPanelType, out GameObject dictPanel)){
                dictPanel.transform.GetChild(0).gameObject.SetActive(true);
                MovePanelLevel(eUIPanelType, uILevel);
                if(isInsertToList){
                    uiMgr.InsertPanel(dictPanel);
                    EventMgr.Broadcast(GameEvents.ShowBackButtonPanelNotify);
                }
                    
            }else{
                SpawnPanel(eUIPanelType,uILevel,isInsertToList, addInfoScriptDel);
                // Debug.Log("add uiPanel to Dict");
                
            }           
           
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

        public void DestroyPanel(EUIPanelType eUIPanelType){
            if(uiMgr.panelDict.TryGetValue(eUIPanelType, out GameObject panel)){
                Destroy(panel);
                uiMgr.panelDict.Remove(eUIPanelType);
            }
        }

        public void ShowNotifyPanel(string text, float countdown){
            canvasMediator.GetCanvasLevel(EUILevel.Level6).GetChild(0).GetComponent<NotifyPanelInfo>().ShowNotifyPanel(text,countdown);
        }

        // public void FloorInitCallback(EUIPanelType uIPanelType, EFloor floor, EFloorPos[] eFloorPos){
        //     GetPanel(uIPanelType).GetComponent<BaseAttackAreaPanelInfo>().UpdateAttackingInfoCallback(floor, eFloorPos);
        // }
    }
}

