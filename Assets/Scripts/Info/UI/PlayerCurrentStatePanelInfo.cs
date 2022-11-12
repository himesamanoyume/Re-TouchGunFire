using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{

    public class PlayerCurrentStatePanelInfo : UIInfo
    {
        public Transform container;
        // RectTransform containerRect;

        public Slider shieldBar;
        public Slider hpBar;
        public Text uidBarText;

        private void Start() {
            Name = "PlayerCurrentStatePanelInfo";
            Init();
        }

        protected override void Init()
        {
            base.Init();
            container = transform.Find("Point/BottomCenter/Container");
            // containerRect = container.GetComponent<RectTransform>();

            shieldBar = container.Find("ShieldBar").GetComponent<Slider>();
            hpBar = container.Find("HpBar").GetComponent<Slider>();
            uidBarText = container.Find("UidBar/Text").GetComponent<Text>();
            EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);

        }

        void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
        void PlayerInfoUpdate(){
            uidBarText.text = "UID:"+GameLoop.Instance.GetComponent<PlayerInfo>().uid.ToString();
        }
    }
}

