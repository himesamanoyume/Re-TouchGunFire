using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;
using ReTouchGunFire.PanelInfo;
using UnityEngine.Events;

namespace ReTouchGunFire.Mediators{
    public class CanvasMediator : IMediator
    {
        private UIMgr m_uiMgr;
        public AbMediator m_abMediator;
        public GameObject m_canvas;
        public UnityAction m_canvasInitedEvent;
        
        public CanvasMediator(){
            Name = "CanvasMediator";  
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
            m_abMediator = GameLoop.Instance.GetMediator<AbMediator>();
            m_canvas = m_abMediator.SyncLoadABRes("prefabs", "Canvas", null);
            m_canvas.name = "Canvas";
            m_canvas.AddComponent<CanvasInfo>();
        }

        public Transform GetCanvasLevel(EUILevel eUILevel){
            switch(eUILevel){
                case EUILevel.Level1:
                    return m_canvas.GetComponent<CanvasInfo>().Level1;
                case EUILevel.Level2:
                    return m_canvas.GetComponent<CanvasInfo>().Level2;
                case EUILevel.Level3:
                    return m_canvas.GetComponent<CanvasInfo>().Level3;
                case EUILevel.Level4:
                    return m_canvas.GetComponent<CanvasInfo>().Level4;
            }
            return null;
        }
    }
}

