using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{

    public class PlayerInfoPanelInfo : UIInfo
    {
        public Slider m_expBar;
        public Text m_playerNameText;
        public Text m_playerLevelText;

        private Transform m_content;

        void Start()
        {
            Name = "PlayerInfoPanelInfo";
            Init();
        }

        public override void Init(){
            base.Init();
            m_content = transform.Find("Point/LeftBottom/Container/Player/Content");
            m_expBar = m_content.Find("ExpItem/ExpBar").GetComponent<Slider>();
            m_playerNameText = m_content.Find("PlayerInfo/PlayerNameText").GetComponent<Text>();
            m_playerLevelText = m_content.Find("PlayerInfo/PlayerLevelText").GetComponent<Text>();
        }
        
    }
}


