using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
    public class BackButtonPanelInfo : UIInfo
    {
        public Button m_backButton;
        private GameObject m_point;

        private void Start() {
            Init();
        }

        public override void Init()
        {
            m_backButton = transform.Find("Point/BackContainer/BackButton").GetComponent<Button>();
            m_point = transform.GetChild(0).gameObject;
            m_point.SetActive(false);
        }
    }
}


