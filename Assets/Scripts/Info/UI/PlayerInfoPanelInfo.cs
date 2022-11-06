using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{

    public sealed class PlayerInfoPanelInfo : UIInfo
    {
        public Slider expBar;
        public Text playerNameText;
        public Text playerLevelText;

        public PanelMediator panelMediator;

        private Transform content;
        PlayerInfo playerInfo;

        void Start()
        {
            Name = "PlayerInfoPanelInfo";
            Init();
        }

        protected sealed override void Init(){
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();
            content = transform.Find("Point/LeftBottom/Container/Player/Content");
            expBar = content.Find("ExpItem/ExpBar").GetComponent<Slider>();
            playerNameText = content.Find("PlayerInfo/PlayerNameText").GetComponent<Text>();
            playerLevelText = content.Find("PlayerInfo/PlayerLevelText").GetComponent<Text>();
            EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }
        
        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            panelMediator.MovePanelLevel(EUIPanelType.PlayerInfoPanel, EUILevel.Level1);
        }

        void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
        void PlayerInfoUpdate(){
            Loom.QueueOnMainThread(()=>{
                playerNameText.text = playerInfo.playerName;
                playerLevelText.text = playerInfo.level.ToString();
                expBar.value = playerInfo.currentExp;
            });
        }

    }
}


