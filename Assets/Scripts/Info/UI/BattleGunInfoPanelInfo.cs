using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BattleGunInfoPanelInfo : UIInfo
    {
        
        void Start()
        {
            Name = "BattleGunInfoPanelInfo";
            currentLevel = EUILevel.Level3;
            Init();
        }

        public Transform mainGun;
        public Transform handGun;
        public Button mainGunCube;
        public Button handGunCube;
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

        private Color uncheckedColor = new Color(0,0,0,0.4f);
        private Color checkedColor = new Color(0.7f,0.7f,0.7f,0.4f);
        public PanelMediator panelMediator;

        protected sealed override void Init()
        {
            base.Init();
            
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            mainGun = transform.Find("Point/BottomMiddleCenter/Container/MainGunCube");
            handGun = transform.Find("Point/BottomMiddleCenter/Container/HandGunCube");
            mainGunCube = mainGun.GetComponent<Button>();
            handGunCube = handGun.GetComponent<Button>();

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

            mainGunBG.color = checkedColor;

            mainGunCube.onClick.AddListener(()=>{
                mainGunBG.color = checkedColor;
                handGunBG.color = uncheckedColor;
            });

            handGunCube.onClick.AddListener(()=>{
                mainGunBG.color = uncheckedColor;
                handGunBG.color = checkedColor;
            });

            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            panelMediator.MovePanelLevel(EUIPanelType.BattleGunInfoPanel, EUILevel.Level3);
        }
    }
}

