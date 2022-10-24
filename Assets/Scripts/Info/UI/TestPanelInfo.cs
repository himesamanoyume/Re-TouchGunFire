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
            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
        }

    }
}

