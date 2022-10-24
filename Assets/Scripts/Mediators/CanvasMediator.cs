using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;
using ReTouchGunFire.PanelInfo;
using UnityEngine.Events;

namespace ReTouchGunFire.Mediators{
    public class CanvasMediator : IMediator
    {
        private UIMgr uiMgr;
        public AbMediator abMediator;
        public GameObject canvas;
        public UnityAction canvasInitedEvent;
        
        public CanvasMediator(){
            Name = "CanvasMediator";  
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            uiMgr = GameLoop.Instance.gameManager.UIMgr;
            abMediator = GameLoop.Instance.GetMediator<AbMediator>();
            canvas = abMediator.SyncLoadABRes("prefabs", "Canvas", null);
            canvas.name = "Canvas";
            canvas.AddComponent<CanvasInfo>();
        }

        public Transform GetCanvasLevel(EUILevel eUILevel){
            switch(eUILevel){
                case EUILevel.Level1:
                    return canvas.GetComponent<CanvasInfo>().Level1;
                case EUILevel.Level2:
                    return canvas.GetComponent<CanvasInfo>().Level2;
                case EUILevel.Level3:
                    return canvas.GetComponent<CanvasInfo>().Level3;
                case EUILevel.Level4:
                    return canvas.GetComponent<CanvasInfo>().Level4;
            }
            return null;
        }
    }
}

