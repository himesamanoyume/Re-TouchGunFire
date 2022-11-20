using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using Google.Protobuf.Collections;
using SocketProtocol;

namespace ReTouchGunFire.PanelInfo{
    public sealed class MainInfoPanelInfo : UIInfo
    {
        public Text diamondText;
        public Button diamondButton;
        public Text coinText;
        public Button coinButton;

        public InitPlayerInfoRequest initPlayerInfoRequest;
        // PlayerInfo playerInfo;

        private void Start() {
            Name = "MainInfoPanelInfo";
            Init();
        }

        protected sealed override void Init(){
            base.Init();

            // playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();

            initPlayerInfoRequest = (InitPlayerInfoRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.InitPlayerInfo);
            
            diamondButton = transform.Find("Point/InfoContainer/InfoButton_Diamond").GetComponent<Button>();
            diamondText = transform.Find("Point/InfoContainer/InfoButton_Diamond/obj/obj2/InfoText_Diamond").GetComponent<Text>();
            coinButton = transform.Find("Point/InfoContainer/InfoButton_Coin").GetComponent<Button>();
            coinText = transform.Find("Point/InfoContainer/InfoButton_Coin/obj/obj2/InfoText_Coin").GetComponent<Text>();
            initPlayerInfoRequest.SendRequest();
            // EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
            networkMediator.GetPlayerInfo.playerInfoUpdateCallback += UpdatePlayerInfoCallback;
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
        }


        // void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
        // void PlayerInfoUpdate(){
        //     Loom.QueueOnMainThread(()=>{
        //         diamondText.text = playerInfo.diamond.ToString();
        //         coinText.text = playerInfo.coin.ToString();
        //     });
        // }

        public void UpdatePlayerInfoCallback(UpdatePlayerInfoPack updatePlayerInfoPack){
            if (updatePlayerInfoPack.Uid == networkMediator.playerSelfUid)
            {
                diamondText.text = updatePlayerInfoPack.Diamond.ToString();
                coinText.text = updatePlayerInfoPack.Coin.ToString();
            }
        }
    }

}

