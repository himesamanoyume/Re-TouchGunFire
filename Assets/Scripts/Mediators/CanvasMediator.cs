using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.PanelInfo;
using UnityEngine.Events;

namespace ReTouchGunFire.Mediators{
    public class CanvasMediator : IMediator
    {
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
            abMediator = GameLoop.Instance.GetMediator<AbMediator>();
            canvas = abMediator.FristTimeSyncLoadABRes("prefabs", "Canvas", null);
            canvas.name = "Canvas";
            canvas.AddComponent<CanvasInfo>();
            canvasInfo = canvas.GetComponent<CanvasInfo>();
        }

        CanvasInfo canvasInfo;
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
                case EUILevel.Level5:
                    return canvasInfo.level5;
                case EUILevel.Level6:
                    return canvasInfo.level6;
                case EUILevel.LevelBackButton:
                    return canvasInfo.levelBackButton;
                case EUILevel.LevelTwiceConfirm:
                    return canvasInfo.levelTwiceConfirm;
                case EUILevel.LevelLoading:
                    return canvasInfo.levelLoading;
            }
            return null;
        }
    }
}

