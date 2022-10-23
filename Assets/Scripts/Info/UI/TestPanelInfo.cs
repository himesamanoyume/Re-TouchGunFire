using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.Mgrs;


namespace ReTouchGunFire.PanelInfo{
    public class TestPanelInfo : UIInfo
    {
        public Button m_point;
        public PanelMediator m_panelMediator;
        void Start()
        {
            Name = "TestPanelInfo";
            Init();
        }

        public override void Init()
        {
            base.Init();
            m_panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            m_point = transform.GetChild(0).GetComponent<Button>();
            m_point.onClick.AddListener(()=>{
                m_panelMediator.PopPanel(false);
                EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
        }

    }
}

