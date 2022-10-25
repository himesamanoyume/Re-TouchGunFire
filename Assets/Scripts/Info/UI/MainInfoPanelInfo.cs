using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
    public sealed class MainInfoPanelInfo : UIInfo
    {
        public Text diamondText;
        public Button diamondButton;
        public Text coinText;
        public Button coinButton;

        private void Start() {
            Name = "MainInfoPanelInfo";
            Init();
        }

        protected sealed override void Init(){
            base.Init();
            diamondButton = transform.Find("Point/InfoContainer/InfoButton_Diamond").GetComponent<Button>();
            diamondText = transform.Find("Point/InfoContainer/InfoButton_Diamond/obj/obj2/InfoText_Diamond").GetComponent<Text>();
            coinButton = transform.Find("Point/InfoContainer/InfoButton_Coin").GetComponent<Button>();
            coinText = transform.Find("Point/InfoContainer/InfoButton_Coin/obj/obj2/InfoText_Coin").GetComponent<Text>();
        }
    }

}

