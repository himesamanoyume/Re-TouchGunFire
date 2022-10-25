using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.Mgrs;


namespace ReTouchGunFire.PanelInfo{
    public class TestPanelInfo : UIInfo
    {
        public Button point;
        public PanelMediator panelMediator;
        //temp
        public Button backpackCube;
        //end
        void Start()
        {
            Name = "TestPanelInfo";
            Init();
        }

        public override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            point = transform.GetChild(0).GetComponent<Button>();
            backpackCube = transform.Find("Point/BackpackCube").GetComponent<Button>();
            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
            //temp
            backpackCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.BackpackPanel, EUILevel.Level2, true,(GameObject obj)=>{
                    obj.AddComponent<BackpackPanelInfo>();
                });
            });
            //end
        }

    }
}

