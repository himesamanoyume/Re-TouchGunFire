using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.Mgrs{
    public sealed class UIMgr : IManager
    {
        public CanvasMediator m_canvasMediator;
        private List<GameObject> m_PanelList = new List<GameObject>();
        public UIMgr(){
            Name = "UIMgr";
        }

        public override void Init(){
            m_canvasMediator = GameLoop.Instance.GetMediator<CanvasMediator>();
        }

        public void PushPanel(EUILevel uILevel, GameObject uIPanel){
            m_PanelList.Insert(0, uIPanel);
            uIPanel.transform.SetParent(m_canvasMediator.GetCanvasLevel(uILevel));
        }

        

        public void PopPanel(){
            GameObject.Destroy(m_PanelList[0]);
            m_PanelList.Remove(m_PanelList[0]);
        }

    }
}

