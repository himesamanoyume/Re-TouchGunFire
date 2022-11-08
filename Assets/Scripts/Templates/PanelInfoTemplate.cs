using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;


namespace ReTouchGunFire.PanelInfo{

    public class PanelInfoTemplate : UIInfo
    {
        public PanelMediator panelMediator;

        void Start()
        {
            Name = "CustomPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            //do something
        }
    }
}


