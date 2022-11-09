using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;


namespace ReTouchGunFire.PanelInfo{

    public class FriendPlayerInfoBarInfo : UIInfo
    {
        public GetPlayerBaseInfoRequest getPlayerBaseInfoRequest;
        public AcceptFriendRequestRequest acceptFriendRequestRequest;
        public RefuseFriendRequestRequest refuseFriendRequestRequest;
        public DeleteFriendRequest deleteFriendRequest;

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
        public Button refuseFriendRequestButton;
        public Text onlineStateText;

        protected sealed override void Init()
        {
            base.Init();

            getPlayerBaseInfoRequest = (GetPlayerBaseInfoRequest)requestMediator.GetRequest(ActionCode.GetPlayerBaseInfo);
            acceptFriendRequestRequest = (AcceptFriendRequestRequest)requestMediator.GetRequest(ActionCode.AcceptFriendRequest);
            refuseFriendRequestRequest = (RefuseFriendRequestRequest)requestMediator.GetRequest(ActionCode.RefuseFriendRequest);
            deleteFriendRequest = (DeleteFriendRequest)requestMediator.GetRequest(ActionCode.DeleteFriend);

            //do something
            deleteFriendButton = transform.Find("Content/ButtonList/DeleteFriendButton").GetComponent<Button>();
            inviteMyTeamButton = transform.Find("Content/ButtonList/InviteMyTeamButton").GetComponent<Button>();
            acceptFriendRequestButton = transform.Find("Content/ButtonList/AcceptFriendRequestButton").GetComponent<Button>();
            refuseFriendRequestButton = transform.Find("Content/ButtonList/RefuseFriendRequestButton").GetComponent<Button>();
            playerNameText = transform.Find("Content/PlayerNameText").GetComponent<Text>();
            onlineStateText = transform.Find("Content/OnlineText").GetComponent<Text>();
            levelText = transform.Find("Content/LevelText").GetComponent<Text>();
            
            getPlayerBaseInfoRequest.SendRequest(playerUid, this);
            if(isRequestType){
                RequestType();
            }else
            {
                FriendType();
            }

            deleteFriendButton.onClick.AddListener(()=>{
                deleteFriendRequest.SendRequest(playerUid, this);
            });

            acceptFriendRequestButton.onClick.AddListener(()=>{
                acceptFriendRequestRequest.SendRequest(playerUid, this);
            });

            refuseFriendRequestButton.onClick.AddListener(()=>{
                refuseFriendRequestRequest.SendRequest(playerUid, this);
            });

            inviteMyTeamButton.onClick.AddListener(()=>{
                //unfinished
            });
        }

        public bool isRequestType = false;

        public void FriendType(){
            acceptFriendRequestButton.gameObject.SetActive(false);
            refuseFriendRequestButton.gameObject.SetActive(false);
            deleteFriendButton.gameObject.SetActive(true);
            inviteMyTeamButton.gameObject.SetActive(true);
        }

        public void RequestType(){
            deleteFriendButton.gameObject.SetActive(false);
            inviteMyTeamButton.gameObject.SetActive(false);
            refuseFriendRequestButton.gameObject.SetActive(true);
            acceptFriendRequestButton.gameObject.SetActive(true);

        }

        public void GetPlayerBaseInfoCallback(PlayerInfoPack playerInfoPack){
            playerNameText.text = playerInfoPack.PlayerName;
            playerNameStr = playerInfoPack.PlayerName;
            levelText.text = "Lv."+playerInfoPack.Level.ToString();
            levelStr = playerInfoPack.Level.ToString();
        }

        public void AcceptFriendRequestCallback(){
            Destroy(gameObject);
        }

        public void RefuseFriendRequestCallback(){
            Destroy(gameObject);
        }

        public void DeleteFriendCallback(){
            Destroy(gameObject);
        }
    }
}


