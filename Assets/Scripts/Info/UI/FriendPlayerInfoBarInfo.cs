using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;


namespace ReTouchGunFire.PanelInfo{

    public class FriendPlayerInfoBarInfo : UIInfo
    {
        [SerializeField] GetPlayerBaseInfoRequest getPlayerBaseInfoRequest;
        [SerializeField] AcceptFriendRequestRequest acceptFriendRequestRequest;
        [SerializeField] RefuseFriendRequestRequest refuseFriendRequestRequest;
        [SerializeField] DeleteFriendRequest deleteFriendRequest;
        [SerializeField] InviteTeamRequest inviteTeamRequest;
        [SerializeField] JoinTeamRequestRequest joinTeamRequestRequest;
        [SerializeField] KickPlayerRequest kickPlayerRequest;

        void Start()
        {
            Name = "FriendPlayerInfoBarInfo";
            Init();
        }

        public int playerUid;
        [SerializeField] Text playerNameText;
        [SerializeField] string playerNameStr;
        [SerializeField] Text levelText;
        [SerializeField] string levelStr;
        [SerializeField] Button inviteMyTeamButton;
        [SerializeField] Button deleteFriendButton;
        [SerializeField] Button acceptFriendRequestButton;
        [SerializeField] Button refuseFriendRequestButton;
        [SerializeField] Button kickPlayerButton;
        [SerializeField] Button joinTeamRequestButton;
        [SerializeField] Text onlineStateText;
        [SerializeField] Text uidText;

        Color green = new Color(0.4f, 0.8f, 0.1f);
        Color grey = new Color(0.5f, 0.5f, 0.5f);

        protected sealed override void Init()
        {
            base.Init();

            getPlayerBaseInfoRequest = (GetPlayerBaseInfoRequest)requestMediator.GetRequest(ActionCode.GetPlayerBaseInfo);
            acceptFriendRequestRequest = (AcceptFriendRequestRequest)requestMediator.GetRequest(ActionCode.AcceptFriendRequest);
            refuseFriendRequestRequest = (RefuseFriendRequestRequest)requestMediator.GetRequest(ActionCode.RefuseFriendRequest);
            deleteFriendRequest = (DeleteFriendRequest)requestMediator.GetRequest(ActionCode.DeleteFriend);
            inviteTeamRequest = (InviteTeamRequest)requestMediator.GetRequest(ActionCode.InviteTeam);
            joinTeamRequestRequest = (JoinTeamRequestRequest)requestMediator.GetRequest(ActionCode.JoinTeamRequest);
            kickPlayerRequest = (KickPlayerRequest)requestMediator.GetRequest(ActionCode.KickPlayer);

            //do something
            deleteFriendButton = transform.Find("Content/ButtonList/DeleteFriendButton").GetComponent<Button>();
            inviteMyTeamButton = transform.Find("Content/ButtonList/InviteMyTeamButton").GetComponent<Button>();
            acceptFriendRequestButton = transform.Find("Content/ButtonList/AcceptFriendRequestButton").GetComponent<Button>();
            refuseFriendRequestButton = transform.Find("Content/ButtonList/RefuseFriendRequestButton").GetComponent<Button>();
            joinTeamRequestButton = transform.Find("Content/ButtonList/JoinTeamRequestButton").GetComponent<Button>();
            kickPlayerButton = transform.Find("Content/ButtonList/KickPlayerButton").GetComponent<Button>();
            playerNameText = transform.Find("Content/PlayerNameText").GetComponent<Text>();
            onlineStateText = transform.Find("Content/OnlineText").GetComponent<Text>();
            levelText = transform.Find("Content/LevelText").GetComponent<Text>();
            uidText = transform.Find("Content/UidText").GetComponent<Text>();
            
            getPlayerBaseInfoRequest.SendRequest(playerUid, this);

            switch(type){
                case EFriendPlayerInfoBarType.RequestType:
                    RequestType();
                break;
                case EFriendPlayerInfoBarType.TeammateType:
                    TeammateType();
                break;
                default:
                    FriendType();
                break;
            }

            deleteFriendButton.onClick.AddListener(()=>{
                panelMediator.ShowTwiceConfirmPanel("真的要删除好友吗?",10f,()=>{
                    deleteFriendRequest.SendRequest(playerUid, this);
                });
            });

            acceptFriendRequestButton.onClick.AddListener(()=>{
                acceptFriendRequestRequest.SendRequest(playerUid, this);
            });

            refuseFriendRequestButton.onClick.AddListener(()=>{
                refuseFriendRequestRequest.SendRequest(playerUid, this);
            });

            inviteMyTeamButton.onClick.AddListener(()=>{
                inviteTeamRequest.SendRequest(playerUid);
            });

            kickPlayerButton.onClick.AddListener(()=>{
                kickPlayerRequest.SendRequest(playerUid);
            });

            joinTeamRequestButton.onClick.AddListener(()=>{
                joinTeamRequestRequest.SendRequest(playerUid);
            });

        }

        public EFriendPlayerInfoBarType type = EFriendPlayerInfoBarType.FriendType;
        

        public void FriendType(){
            acceptFriendRequestButton.gameObject.SetActive(false);
            refuseFriendRequestButton.gameObject.SetActive(false);
            deleteFriendButton.gameObject.SetActive(true);
            kickPlayerButton.gameObject.SetActive(false);
        }

        public void RequestType(){
            deleteFriendButton.gameObject.SetActive(false);
            refuseFriendRequestButton.gameObject.SetActive(true);
            acceptFriendRequestButton.gameObject.SetActive(true);
            onlineStateText.gameObject.SetActive(false);
            kickPlayerButton.gameObject.SetActive(false);
            joinTeamRequestButton.gameObject.SetActive(false);
        }

        public void TeammateType(){
            deleteFriendButton.gameObject.SetActive(false);
            refuseFriendRequestButton.gameObject.SetActive(false);
            acceptFriendRequestButton.gameObject.SetActive(false);
            onlineStateText.gameObject.SetActive(false);
            if(networkMediator.teamMasterPlayerUid == networkMediator.playerSelfUid){
                kickPlayerButton.gameObject.SetActive(true);
            }else
            {
                kickPlayerButton.gameObject.SetActive(false);
            }
            
        }

        public void GetPlayerBaseInfoCallback(PlayerInfoPack playerInfoPack){
            if(playerInfoPack.IsTeamMaster){
                playerNameText.text = playerInfoPack.PlayerName + "[队长]";
            }else
            {
                playerNameText.text = playerInfoPack.PlayerName;
            }
            playerNameStr = playerInfoPack.PlayerName;
            levelText.text = "Lv."+playerInfoPack.Level.ToString();
            uidText.text = "UID:"+playerInfoPack.Uid.ToString();

            levelStr = playerInfoPack.Level.ToString();
            if(playerInfoPack.IsOnline){
                onlineStateText.text = "在线";
                onlineStateText.color = green;
                if (EFriendPlayerInfoBarType.TeammateType == type)
                {
                    inviteMyTeamButton.gameObject.SetActive(false);
                    joinTeamRequestButton.gameObject.SetActive(false);
                }else{
                    if (playerInfoPack.IsTeam)
                    {
                        inviteMyTeamButton.gameObject.SetActive(false);
                        if (playerInfoPack.IsSameTeam)
                        {
                            joinTeamRequestButton.gameObject.SetActive(false);
                        }else
                        {
                            joinTeamRequestButton.gameObject.SetActive(true);
                        }
                        
                    }else
                    {
                        inviteMyTeamButton.gameObject.SetActive(true);
                        joinTeamRequestButton.gameObject.SetActive(false);
                    }
                }
            }else
            {
                onlineStateText.text = "离线";
                onlineStateText.color = grey;
                joinTeamRequestButton.gameObject.SetActive(false);
                inviteMyTeamButton.gameObject.SetActive(false);
            }
            
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


