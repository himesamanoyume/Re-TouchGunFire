using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;


namespace ReTouchGunFire.PanelInfo{

    public class PanelInfoTemplate : UIInfo
    {

        void Start()
        {
            Name = "CustomPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();

            //do something
        }
    }
}


