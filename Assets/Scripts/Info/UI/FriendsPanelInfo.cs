using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;
using Google.Protobuf.Collections;


namespace ReTouchGunFire.PanelInfo{

    public class FriendsPanelInfo : UIInfo
    {
        [SerializeField] SearchFriendRequest searchFriendRequest;
        [SerializeField] GetFriendRequestRequest getFriendRequestRequest;
        [SerializeField] GetFriendsRequest getFriendsRequest;
        [SerializeField] GetPlayerBaseInfoRequest getPlayerBaseInfoRequest;
        [SerializeField] SendRequestFriendRequest sendRequestFriendRequest;
        [SerializeField] AcceptFriendRequestRequest acceptFriendRequestRequest;
        [SerializeField] GetTeammatesRequest getTeammatesRequest;
        [SerializeField] LeaveTeamRequest leaveTeamRequest;

        void Start()
        {
            Name = "FriendsPanelInfo";
            Init();
        }

        [SerializeField] Button point;
        //container1
        [SerializeField] Transform container1;
            //PagePart
                [SerializeField] Button friendsPageButton;
                [SerializeField] Button teammatesPageButton;
                [SerializeField] Button friendRequestPageButton;
                [SerializeField] Text friendCountText;
            //end
            //SearchPart
                [SerializeField] InputField searchInputField;
                [SerializeField] Button searchButton;
            //end
            //FriendsPart
                [SerializeField] Transform friendsPartScrollViewContent;
                [SerializeField] GameObject friendPlayerInfoBarTemplate; // UIComponent
            //end
        //container1 end
        //container2
        [SerializeField] Transform container2;
            //SearchPlayerPart
                [SerializeField] Transform searchPlayerInfoBar;
                    private int targetPlayerUid;
                    [SerializeField] Text playerNameText;
                    [SerializeField] Text levelText;
                    [SerializeField] Button addFriendButton;
                [SerializeField] Button closeButton;
            //end
        //container2 end
        //container3
        [SerializeField] Transform container3;
            [SerializeField] Button leaveTeamButton;
        //container3 end

        protected sealed override void Init()
        {
            base.Init();
            
            getFriendRequestRequest = (GetFriendRequestRequest)requestMediator.GetRequest(ActionCode.GetFriendRequest);

            getFriendsRequest = (GetFriendsRequest)requestMediator.GetRequest(ActionCode.GetFriends);

            searchFriendRequest = (SearchFriendRequest)requestMediator.GetRequest(ActionCode.SearchFriend);

            sendRequestFriendRequest = (SendRequestFriendRequest)requestMediator.GetRequest(ActionCode.SendRequestFriend);

            acceptFriendRequestRequest = (AcceptFriendRequestRequest)requestMediator.GetRequest(ActionCode.AcceptFriendRequest);

            getPlayerBaseInfoRequest = (GetPlayerBaseInfoRequest)requestMediator.GetRequest(ActionCode.GetPlayerBaseInfo);

            getTeammatesRequest = (GetTeammatesRequest)requestMediator.GetRequest(ActionCode.GetTeammates);

            leaveTeamRequest = (LeaveTeamRequest)requestMediator.GetRequest(ActionCode.LeaveTeam);

            //bind

            point = transform.Find("Point").GetComponent<Button>();

            container1 = transform.Find("Point/Center/Container1");

            friendsPageButton = container1.Find("PagePart/Page/Content/FriendsPageButton").GetComponent<Button>();
            teammatesPageButton = container1.Find("PagePart/Page/Content/TeammatesPageButton").GetComponent<Button>();
            friendRequestPageButton = container1.Find("PagePart/Page/Content/FriendRequestPageButton").GetComponent<Button>();
            friendCountText = container1.Find("PagePart/FriendCountContent/FriendCountText").GetComponent<Text>();

            searchInputField = container1.Find("SearchPart/SearchInputField").GetComponent<InputField>();
            searchButton = container1.Find("SearchPart/SearchButton").GetComponent<Button>();

            friendsPartScrollViewContent = container1.Find("FriendsPart/Scroll View/Viewport/Content");

            LoadTemplate();
            
            container2 = transform.Find("Point/Center/Container2");

            searchPlayerInfoBar = container2.Find("SearchPlayerPart/Scroll View/Viewport/Content/SearchPlayerInfoBar");

            playerNameText = searchPlayerInfoBar.Find("Content/PlayerNameText").GetComponent<Text>();
            levelText = searchPlayerInfoBar.Find("Content/LevelText").GetComponent<Text>();
            addFriendButton = searchPlayerInfoBar.Find("Content/ButtonList/AddFriendButton").GetComponent<Button>();

            closeButton = container2.Find("SearchPlayerPart/CloseButton").GetComponent<Button>();

            container3 = transform.Find("Point/Center/Container3");

            leaveTeamButton = container3.Find("ButtonPart/LeaveTeamButton").GetComponent<Button>();

            //end

            getFriendsRequest.SendRequest();

            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });

            friendsPageButton.onClick.AddListener(()=>{
                container2.GetComponent<RectTransform>().offsetMax = offScreen;
                leaveTeamButton.gameObject.SetActive(false);
                getFriendsRequest.SendRequest();
            });

            teammatesPageButton.onClick.AddListener(()=>{
                container2.GetComponent<RectTransform>().offsetMax = offScreen;
                for (int i = 0; i < friendsPartScrollViewContent.childCount; i++)
                {
                    Destroy(friendsPartScrollViewContent.GetChild(i).gameObject);
                }
                getTeammatesRequest.SendRequest(networkMediator.playerSelfUid);
            });

            friendRequestPageButton.onClick.AddListener(()=>{
                container2.GetComponent<RectTransform>().offsetMax = offScreen;
                leaveTeamButton.gameObject.SetActive(false);
                getFriendRequestRequest.SendRequest();
            });

            searchButton.onClick.AddListener(()=>{
                int _targetPlayerUid = int.Parse(searchInputField.text);
                // Debug.Log(_targetPlayerUid);
                searchFriendRequest.SendRequest(_targetPlayerUid);
                targetPlayerUid = _targetPlayerUid;
            });

            closeButton.onClick.AddListener(()=>{
                container2.GetComponent<RectTransform>().offsetMax = offScreen;
                leaveTeamButton.gameObject.SetActive(false);
            });

            addFriendButton.onClick.AddListener(()=>{
                sendRequestFriendRequest.SendRequest(targetPlayerUid);
            });

            leaveTeamButton.onClick.AddListener(()=>{
                leaveTeamRequest.SendRequest();
                leaveTeamButton.gameObject.SetActive(false);
            });
            leaveTeamButton.gameObject.SetActive(false);
        }

        void LoadTemplate(){
            friendPlayerInfoBarTemplate = abMediator.SyncLoadABRes("prefabs","FriendPlayerInfoBar");
        }

        public void SearchFriendCallback(MainPack mainPack){
            container2.GetComponent<RectTransform>().offsetMax = inTheScreen;
            playerNameText.text = mainPack.PlayerInfoPack.PlayerName;
            levelText.text = "Lv." + mainPack.PlayerInfoPack.Level.ToString();
        }

        public void GetFriendRequestCallback(RepeatedField<FriendsPack> friendsPacks){
            // Debug.Log(friendsPartScrollViewContent.childCount);
            for (int i = 0; i < friendsPartScrollViewContent.childCount; i++)
            {
                Destroy(friendsPartScrollViewContent.GetChild(i).gameObject);
            }
            
            foreach (var item in friendsPacks)
            {
                GameObject playerInfoBar = Instantiate(friendPlayerInfoBarTemplate, friendsPartScrollViewContent);
                playerInfoBar.AddComponent<FriendPlayerInfoBarInfo>().playerUid = item.Player1Uid;
                playerInfoBar.GetComponent<FriendPlayerInfoBarInfo>().type = EFriendPlayerInfoBarType.RequestType;
            }

        }

        public void GetFriendsCallback(RepeatedField<FriendsPack> friendsPacks){
            for (int i = 0; i < friendsPartScrollViewContent.childCount; i++)
            {
                Destroy(friendsPartScrollViewContent.GetChild(i).gameObject);
            }
            int count = 0;
            friendCountText.text = string.Format("好友数 {0}/30",count);
            foreach (var item in friendsPacks)
            {
                count++;
                friendCountText.text = string.Format("好友数 {0}/30",count);
                GameObject playerInfoBar = Instantiate(friendPlayerInfoBarTemplate, friendsPartScrollViewContent);
                playerInfoBar.AddComponent<FriendPlayerInfoBarInfo>().playerUid = item.Player1Uid;
            }
        }

        public void GetTeammatesCallback(MainPack mainPack){
            RepeatedField<FriendsPack> friendsPacks = mainPack.FriendsPack;
            for (int i = 0; i < friendsPartScrollViewContent.childCount; i++)
            {
                Destroy(friendsPartScrollViewContent.GetChild(i).gameObject);
            }
            foreach (var item in friendsPacks)
            {
                GameObject playerInfoBar = Instantiate(friendPlayerInfoBarTemplate, friendsPartScrollViewContent);
                playerInfoBar.AddComponent<FriendPlayerInfoBarInfo>().playerUid = item.Player1Uid;
                playerInfoBar.GetComponent<FriendPlayerInfoBarInfo>().type = EFriendPlayerInfoBarType.TeammateType;
            }
            if(friendsPacks.Count>0)
                leaveTeamButton.gameObject.SetActive(true);
        }

    }
}

