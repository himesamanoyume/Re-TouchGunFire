using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public class TestPanelInfo : UIInfo
    {
        public Button point;
        //temp
        public Button backpackCube;
        //end
        void Start()
        {
            Name = "TestPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();

            point = transform.GetChild(0).GetComponent<Button>();
            backpackCube = transform.Find("Point/BackpackCube").GetComponent<Button>();
            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
            //temp
            backpackCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.BackpackPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<BackpackPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                    
                });
            });
            //end
        }

    }
}

