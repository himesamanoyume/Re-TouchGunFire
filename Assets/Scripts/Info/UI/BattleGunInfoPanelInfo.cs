using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BattleGunInfoPanelInfo : UIInfo
    {
        
        void Start()
        {
            Name = "BattleGunInfoPanelInfo";
            Init();
        }

        public Transform mainGun;
        public Transform handGun;
        public Slider mainGunReloadingBar;
        public Slider handGunReloadingBar;
        public Image mainGunBG;
        public Image handGunBG;
        public Text mainGunNameText;
        public Text handGunNameText;
        public Text mainGunAmmoText;
        public Text handGunAmmoText;
        public Image mainGunQuality;
        public Image handGunQuality;

        protected sealed override void Init()
        {
            base.Init();
            mainGun = transform.Find("Point/BottomMiddleCenter/Container/MainGun");
            handGun = transform.Find("Point/BottomMiddleCenter/Container/HandGun");

            mainGunReloadingBar = mainGun.Find("ReloadingBar").GetComponent<Slider>();
            mainGunBG = mainGun.GetComponent<Image>();
            mainGunNameText = mainGun.Find("GunName/GunNameText").GetComponent<Text>();
            mainGunQuality = mainGun.Find("GunName/GunQuality").GetComponent<Image>();
            mainGunAmmoText = mainGun.Find("AmmoText").GetComponent<Text>();
            

            handGunReloadingBar = handGun.Find("ReloadingBar").GetComponent<Slider>();
            handGunBG = handGun.GetComponent<Image>();
            handGunNameText = handGun.Find("GunName/GunNameText").GetComponent<Text>();
            handGunQuality = handGun.Find("GunName/GunQuality").GetComponent<Image>();
            handGunAmmoText = handGun.Find("AmmoText").GetComponent<Text>();
        }
    }
}

