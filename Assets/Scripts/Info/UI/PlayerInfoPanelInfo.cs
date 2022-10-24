using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{

    public class PlayerInfoPanelInfo : UIInfo
    {
        public Slider expBar;
        public Text playerNameText;
        public Text playerLevelText;

        private Transform content;

        void Start()
        {
            Name = "PlayerInfoPanelInfo";
            Init();
        }

        public override void Init(){
            base.Init();
            content = transform.Find("Point/LeftBottom/Container/Player/Content");
            expBar = content.Find("ExpItem/ExpBar").GetComponent<Slider>();
            playerNameText = content.Find("PlayerInfo/PlayerNameText").GetComponent<Text>();
            playerLevelText = content.Find("PlayerInfo/PlayerLevelText").GetComponent<Text>();
        }
        
    }
}


