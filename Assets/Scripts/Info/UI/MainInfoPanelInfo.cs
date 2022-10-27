using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class MainInfoPanelInfo : UIInfo
    {
        public Text diamondText;
        public Button diamondButton;
        public Text coinText;
        public Button coinButton;

        public PanelMediator panelMediator;

        private void Start() {
            Name = "MainInfoPanelInfo";
            currentLevel = EUILevel.Level1;
            Init();
        }

        protected sealed override void Init(){
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            diamondButton = transform.Find("Point/InfoContainer/InfoButton_Diamond").GetComponent<Button>();
            diamondText = transform.Find("Point/InfoContainer/InfoButton_Diamond/obj/obj2/InfoText_Diamond").GetComponent<Text>();
            coinButton = transform.Find("Point/InfoContainer/InfoButton_Coin").GetComponent<Button>();
            coinText = transform.Find("Point/InfoContainer/InfoButton_Coin/obj/obj2/InfoText_Coin").GetComponent<Text>();
        
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
        }
    }

}

