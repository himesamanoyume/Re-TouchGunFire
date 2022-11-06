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
        public InitPlayerInfoRequest initPlayerInfoRequest;
        PlayerInfo playerInfo;

        private void Start() {
            Name = "MainInfoPanelInfo";
            Init();
        }

        protected sealed override void Init(){
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();
            initPlayerInfoRequest = gameObject.AddComponent<InitPlayerInfoRequest>();
            diamondButton = transform.Find("Point/InfoContainer/InfoButton_Diamond").GetComponent<Button>();
            diamondText = transform.Find("Point/InfoContainer/InfoButton_Diamond/obj/obj2/InfoText_Diamond").GetComponent<Text>();
            coinButton = transform.Find("Point/InfoContainer/InfoButton_Coin").GetComponent<Button>();
            coinText = transform.Find("Point/InfoContainer/InfoButton_Coin/obj/obj2/InfoText_Coin").GetComponent<Text>();
            initPlayerInfoRequest.SendRequest();
            EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
        }


        void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
        void PlayerInfoUpdate(){
            Loom.QueueOnMainThread(()=>{
                diamondText.text = playerInfo.diamond.ToString();
                coinText.text = playerInfo.coin.ToString();
            });
        }
    }

}

