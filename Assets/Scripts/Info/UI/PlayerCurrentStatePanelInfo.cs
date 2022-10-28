using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{

    public class PlayerCurrentStatePanelInfo : UIInfo
    {
        public Transform container;

        private void Start() {
            Name = "PlayerCurrentStatePanelInfo";
            Init();
        }

        protected override void Init()
        {
            base.Init();
        }
    }
}

