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

        public Transform joinTeamContent;
        public Text joinText;
        public Button refuseJoinButton;
        public Button acceptJoinButton;
        public Slider joinCountdown;

        public AcceptInviteTeamRequest acceptInviteTeamRequest;
        public RefuseInviteTeamRequest refuseInviteTeamRequest;

        [SerializeField] bool isCountdown = true;
        [SerializeField] bool isAccepted = false;
        [SerializeField] bool isInvite = true;

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

            joinTeamContent = transform.Find("JoinTeamContent");
            joinText = joinTeamContent.Find("JoinText").GetComponent<Text>();
            refuseJoinButton = inviteContent.Find("ButtonList/RefuseButton").GetComponent<Button>();
            acceptJoinButton = inviteContent.Find("ButtonList/AcceptButton").GetComponent<Button>();
            joinCountdown = inviteContent.Find("Countdown").GetComponent<Slider>();
            joinCountdown.maxValue = 10;
            joinCountdown.value = 10;


            refuseButton.onClick.AddListener(()=>{
                refuseInviteTeamRequest.SendRequest(teammateUid);
                Destroy(gameObject);
            });

            acceptButton.onClick.AddListener(()=>{
                acceptInviteTeamRequest.SendRequest(teammateUid);
                isCountdown = false;
                inviteContent.gameObject.SetActive(false);
                joinTeamContent.gameObject.SetActive(false);
                infoContent.gameObject.SetActive(true);
            });

            if (isInvite)
            {
                inviteContent.gameObject.SetActive(true);
                joinTeamContent.gameObject.SetActive(false);
                infoContent.gameObject.SetActive(false);
            }else
            {
                inviteContent.gameObject.SetActive(false);
                joinTeamContent.gameObject.SetActive(true);
                infoContent.gameObject.SetActive(false);
            }

            if (isAccepted)
            {
                isCountdown = false;
                inviteContent.gameObject.SetActive(false);
                joinTeamContent.gameObject.SetActive(false);
                infoContent.gameObject.SetActive(true);
            }
        }

        private void Update() {
            CountDownRunning();
        }

        public void Accepted(){
            isAccepted = true;
        }

        public void AcceptedJoin(){
            isInvite = false;
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


