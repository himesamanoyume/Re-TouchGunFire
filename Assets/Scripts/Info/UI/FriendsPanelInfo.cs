using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;


namespace ReTouchGunFire.PanelInfo{

    public class FriendsPanelInfo : UIInfo
    {
        public PanelMediator panelMediator;
        public AbMediator abMediator;

        void Start()
        {
            Name = "FriendsPanelInfo";
            Init();
        }

        public Button point;
        //container1
        public Transform container1;
            //PagePart
                public Button friendsPageButton;
                public Button friendRequestPageButton;
            //end
            //SearchPart
                public InputField searchInputField;
                public Button searchButton;
            //end
            //FriendsPart
                public Transform friendsPartScrollViewContent;
                public GameObject friendPlayerInfoBarTemplate; // UIComponent
            //end
        //container1 end
        //container2
        public Transform container2;
            //SearchPlayerPart
                public Transform searchPlayerInfoBar;
                    public Text playerNameText;
                    public Text levelText;
                    public Button addFriendButton;
                public Button closeButton;
            //end
        //container2 end

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            abMediator = GameLoop.Instance.GetMediator<AbMediator>();


            //bind

            point = transform.Find("Point").GetComponent<Button>();

            container1 = transform.Find("Point/Center/Container1");

            friendsPageButton = container1.Find("PagePart/Page/Content/FriendsPageButton").GetComponent<Button>();
            friendRequestPageButton = container1.Find("PagePart/Page/Content/FriendRequestPageButton").GetComponent<Button>();

            searchInputField = container1.Find("SearchPart/SearchInputField").GetComponent<InputField>();
            searchButton = container1.Find("SearchPart/SearchButton").GetComponent<Button>();

            friendsPartScrollViewContent = container1.Find("FriendsPart/Scroll View/Viewport/Content");

            EventMgr.AddListener<AbLoadEndNotify>(OnAbLoadEnd);
            
            container2 = transform.Find("Point/Center/Container2");

            searchPlayerInfoBar = container2.Find("SearchPlayerPart/Scroll View/Viewport/Content/SearchPlayerInfoBar");

            playerNameText = searchPlayerInfoBar.Find("Content/PlayerNameText").GetComponent<Text>();
            levelText = searchPlayerInfoBar.Find("Content/LevelText").GetComponent<Text>();
            addFriendButton = searchPlayerInfoBar.Find("Content/ButtonList/AddFriendButton").GetComponent<Button>();

            closeButton = container2.Find("SearchPlayerPart/CloseButton").GetComponent<Button>();

            //end

            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
        }

        void OnAbLoadEnd(AbLoadEndNotify evt) => AbLoadEnd();
        void AbLoadEnd(){
            friendPlayerInfoBarTemplate = abMediator.SyncLoadABRes("prefab","FriendPlayerInfoBar", friendsPartScrollViewContent);
        }


    }
}

