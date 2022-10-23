using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.Mgrs{
    public sealed class UIMgr : IManager
    {
        public CanvasMediator m_canvasMediator;
        private List<GameObject> m_panelList = new List<GameObject>();
        public Dictionary<EUIPanelType, GameObject> m_panelDict = new Dictionary<EUIPanelType, GameObject>();
        public UIMgr(){
            Name = "UIMgr";
        }

        public override void Init(){
            m_canvasMediator = GameLoop.Instance.GetMediator<CanvasMediator>();
        }

        public void InsertPanel(GameObject panel){
            m_panelList.Insert(0, panel);
        }

        public void CheckPanelList(){
            if(m_panelList.Count > 0){

            }
        }

        /// <summary>
        /// 适合已经生成过的面板 在点击对应按钮时显示该面板
        /// </summary>
        /// <param name="eUIPanelType"></param>
        /// <param name="isInsertToList"></param>
        // public void PushPanel(EUILevel uILevel, GameObject uIPanel, EUIPanelType eUIPanelType, bool isInsertToList){

        //     if(m_panelDict.TryGetValue(eUIPanelType, out GameObject dictPanel)){
        //         dictPanel.transform.GetChild(0).gameObject.SetActive(true);
        //         if(isInsertToList)
        //             m_panelList.Insert(0, dictPanel);
        //     }else{
        //         m_panelDict.Add(eUIPanelType, uIPanel);
        //         uIPanel.transform.SetParent(m_canvasMediator.GetCanvasLevel(uILevel));
        //         if(isInsertToList)
        //             m_panelList.Insert(0, dictPanel);
        //     }
        // }

        public void PeekPanel(){
            // m_panelList[0].gameObject.SetActive(false);
        }

        public void PopPanel(bool isDestroy){
            if(isDestroy){
                GameObject.Destroy(m_panelList[0]);
            }else{
                m_panelList[0].transform.GetChild(0).gameObject.SetActive(false);
            }
            
            m_panelList.Remove(m_panelList[0]);
        }

    }
}

