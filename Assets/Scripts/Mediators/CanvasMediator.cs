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
            canvasInfo = canvas.GetComponent<CanvasInfo>();
        }

        CanvasInfo canvasInfo;
        public Transform level1;
        public Transform level2;
        public Transform level3;
        public Transform level4;
        public Transform levelLoading;

        public Transform GetCanvasLevel(EUILevel eUILevel){
            switch(eUILevel){
                case EUILevel.Level1:
                    return canvasInfo.level1;
                case EUILevel.Level2:
                    return canvasInfo.level2;
                case EUILevel.Level3:
                    return canvasInfo.level3;
                case EUILevel.Level4:
                    return canvasInfo.level4;
                case EUILevel.LevelLoading:
                    return canvasInfo.levelLoading;
            }
            return null;
        }
    }
}

