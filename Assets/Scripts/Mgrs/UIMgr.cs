using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.Mgrs{
    public sealed class UIMgr : IManager
    {
        public CanvasMediator canvasMediator;
        private List<GameObject> panelList = new List<GameObject>();
        public Dictionary<EUIPanelType, GameObject> panelDict = new Dictionary<EUIPanelType, GameObject>();
        public UIMgr(){
            Name = "UIMgr";
        }

        public override void Init(){
            canvasMediator = GameLoop.Instance.GetMediator<CanvasMediator>();
        }

        public void InsertPanel(GameObject panel){
            panelList.Insert(0, panel);
        }

        public void CheckPanelList(){
            if(panelList.Count > 0){

            }
        }

        /// <summary>
        /// 适合已经生成过的面板 在点击对应按钮时显示该面板
        /// </summary>
        /// <param name="eUIPanelType"></param>
        /// <param name="isInsertToList"></param>
        // public void PushPanel(EUILevel uILevel, GameObject uIPanel, EUIPanelType eUIPanelType, bool isInsertToList){

        //     if(panelDict.TryGetValue(eUIPanelType, out GameObject dictPanel)){
        //         dictPanel.transform.GetChild(0).gameObject.SetActive(true);
        //         if(isInsertToList)
        //             panelList.Insert(0, dictPanel);
        //     }else{
        //         panelDict.Add(eUIPanelType, uIPanel);
        //         uIPanel.transform.SetParent(canvasMediator.GetCanvasLevel(uILevel));
        //         if(isInsertToList)
        //             panelList.Insert(0, dictPanel);
        //     }
        // }

        public void PeekPanel(){
            // panelList[0].gameObject.SetActive(false);
        }

        public void PopPanel(bool isDestroy){
            if(isDestroy){
                GameObject.Destroy(panelList[0]);
            }else{
                panelList[0].transform.GetChild(0).gameObject.SetActive(false);
            }
            
            panelList.Remove(panelList[0]);
        }

    }
}

