using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
    public class MainInfoPanelInfo : UIInfo
    {
        public Text m_diamondText;
        public Button m_diamondButton;
        public Text m_coinText;
        public Button m_coinButton;

        public override void Init(){
            m_diamondButton = transform.Find("Point/InfoContainer/InfoButton_Diamond").GetComponent<Button>();
            m_diamondText = transform.Find("Point/InfoContainer/InfoButton_Diamond/obj/obj2/InfoText_Diamond").GetComponent<Text>();
            m_coinButton = transform.Find("Point/InfoContainer/InfoButton_Coin").GetComponent<Button>();
            m_coinText = transform.Find("Point/InfoContainer/InfoButton_Coin/obj/obj2/InfoText_Coin").GetComponent<Text>();
        }
    }

}

