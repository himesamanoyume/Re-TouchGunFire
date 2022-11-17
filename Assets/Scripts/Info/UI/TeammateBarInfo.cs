using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;


namespace ReTouchGunFire.PanelInfo{

    public class TeammateBarInfo : UIInfo
    {

        void Start()
        {
            Name = "TeammateBarInfo";
            Init();
        }

        public int teammateUid;

        public Transform infoContent;
        public Slider health;
        public Slider armor;
        public Text playerNameText;


        public Transform inviteContent;
        public Text inviteText;
        public Button refuseButton;
        public Button acceptButton;
        public Slider countdown;

        public AcceptInviteTeamRequest acceptInviteTeamRequest;
        public RefuseInviteTeamRequest refuseInviteTeamRequest;

        [SerializeField] bool isCountdown = true;
        [SerializeField] bool isAccepted = false;

        protected sealed override void Init()
        {
            base.Init();

            acceptInviteTeamRequest = (AcceptInviteTeamRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.AcceptInviteTeam);
            refuseInviteTeamRequest = (RefuseInviteTeamRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.RefuseInviteTeam);

            inviteContent = transform.Find("InviteContent");
            inviteText = inviteContent.Find("InviteText").GetComponent<Text>();
            refuseButton = inviteContent.Find("ButtonList/RefuseButton").GetComponent<Button>();
            acceptButton = inviteContent.Find("ButtonList/AcceptButton").GetComponent<Button>();
            countdown = inviteContent.Find("Countdown").GetComponent<Slider>();
            countdown.maxValue = 10;
            countdown.value = 10;


            infoContent = transform.Find("InfoContent");
            health = infoContent.Find("Health").GetComponent<Slider>();
            armor = infoContent.Find("Armor").GetComponent<Slider>();
            playerNameText = infoContent.Find("PlayerNameText").GetComponent<Text>();

            refuseButton.onClick.AddListener(()=>{
                refuseInviteTeamRequest.SendRequest(teammateUid);
                Destroy(gameObject);
            });

            acceptButton.onClick.AddListener(()=>{
                acceptInviteTeamRequest.SendRequest(teammateUid);
                isCountdown = false;
                inviteContent.gameObject.SetActive(false);
                infoContent.gameObject.SetActive(true);
            });

            if (isAccepted)
            {
                isCountdown = false;
                inviteContent.gameObject.SetActive(false);
                infoContent.gameObject.SetActive(true);
            }
        }

        private void Update() {
            CountDownRunning();
        }

        public void Accepted(){
            isAccepted = true;
        }

        protected override void CountDownRunning()
        {
            if(!isCountdown) return;
            countdown.value -= Time.deltaTime;
            if(countdown.value <= 0){
                countdown.value = 0;
                isCountdown = false;
                Destroy(gameObject);
            }
        }

    }
}


