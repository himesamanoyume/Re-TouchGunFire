using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;


namespace ReTouchGunFire.PanelInfo{

    public class FriendPlayerInfoBarInfo : UIInfo
    {
        public PanelMediator panelMediator;

        public GetPlayerBaseInfoRequest getPlayerBaseInfoRequest;

        void Start()
        {
            Name = "FriendPlayerInfoBarInfo";
            Init();
        }

        public int playerUid;
        public Text playerNameText;
        public string playerNameStr;
        public Text levelText;
        public string levelStr;
        public Button inviteMyTeamButton;
        public Button deleteFriendButton;
        public Button acceptFriendRequestButton;
        public Text onlineStateText;

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            getPlayerBaseInfoRequest = GameLoop.Instance.GetComponent<GetPlayerBaseInfoRequest>();
            //do something
            deleteFriendButton = transform.Find("Content/ButtonList/DeleteFriendButton").GetComponent<Button>();
            inviteMyTeamButton = transform.Find("Content/ButtonList/InviteMyTeamButton").GetComponent<Button>();
            acceptFriendRequestButton = transform.Find("Content/ButtonList/AcceptFriendRequestButton").GetComponent<Button>();
            playerNameText = transform.Find("Content/PlayerNameText").GetComponent<Text>();
            onlineStateText = transform.Find("Content/OnlineText").GetComponent<Text>();
            levelText = transform.Find("Content/LevelText").GetComponent<Text>();
            
            getPlayerBaseInfoRequest.SendRequest(playerUid, gameObject.GetComponent<FriendPlayerInfoBarInfo>());
            if(isRequestType){
                RequestType();
            }else
            {
                FriendType();
            }
        }

        public bool isRequestType = false;

        public void FriendType(){
            acceptFriendRequestButton.gameObject.SetActive(false);

        }

        public void RequestType(){
            deleteFriendButton.gameObject.SetActive(false);
            inviteMyTeamButton.gameObject.SetActive(false);

        }

        public void GetPlayerBaseInfoCallback(PlayerInfoPack playerInfoPack){
            // Debug.Log("GetPlayerBaseInfoCallback " + playerInfoPack.PlayerName);
            playerNameText.text = playerInfoPack.PlayerName;
            playerNameStr = playerInfoPack.PlayerName;
            levelText.text = "Lv."+playerInfoPack.Level.ToString();
            levelStr = playerInfoPack.Level.ToString();
        }


    }
}


