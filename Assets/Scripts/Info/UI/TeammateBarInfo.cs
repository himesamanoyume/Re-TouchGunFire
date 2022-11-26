using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;


namespace ReTouchGunFire.PanelInfo{

    public class TeammateBarInfo : UIInfo
    {

        void Start()
        {
            Name = "TeammateBarInfo";
            Init();
        }

        public int teammateUid;
        public string teammateName;

        public Transform infoContent;
        public Slider health;
        public Slider armor;
        public Text playerNameText;


        [SerializeField] Transform inviteContent;
        [SerializeField] Text inviteText;
        [SerializeField] Button refuseButton;
        [SerializeField] Button acceptButton;
        [SerializeField] Slider countdown;

        [SerializeField] Transform joinTeamContent;
        [SerializeField] Text joinText;
        [SerializeField] Button refuseJoinButton;
        [SerializeField] Button acceptJoinButton;
        [SerializeField] Slider joinCountdown;

        [SerializeField] AcceptInviteTeamRequest acceptInviteTeamRequest;
        [SerializeField] RefuseInviteTeamRequest refuseInviteTeamRequest;
        [SerializeField] AcceptJoinTeamRequest acceptJoinTeamRequest;
        [SerializeField] RefuseJoinTeamRequest refuseJoinTeamRequest;

        [SerializeField] bool isCountdown = true;
        [SerializeField] bool isAccepted = false;
        [SerializeField] bool isInvite = true;

        protected sealed override void Init()
        {
            base.Init();

            acceptInviteTeamRequest = (AcceptInviteTeamRequest)requestMediator.GetRequest(ActionCode.AcceptInviteTeam);
            refuseInviteTeamRequest = (RefuseInviteTeamRequest)requestMediator.GetRequest(ActionCode.RefuseInviteTeam);
            acceptJoinTeamRequest = (AcceptJoinTeamRequest)requestMediator.GetRequest(ActionCode.AcceptJoinTeam);
            refuseJoinTeamRequest = (RefuseJoinTeamRequest)requestMediator.GetRequest(ActionCode.RefuseJoinTeam);

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
            refuseJoinButton = joinTeamContent.Find("ButtonList/RefuseButton").GetComponent<Button>();
            acceptJoinButton = joinTeamContent.Find("ButtonList/AcceptButton").GetComponent<Button>();
            joinCountdown = joinTeamContent.Find("Countdown").GetComponent<Slider>();
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

            refuseJoinButton.onClick.AddListener(()=>{
                refuseJoinTeamRequest.SendRequest(teammateUid);
                Destroy(gameObject);
            });

            acceptJoinButton.onClick.AddListener(()=>{
                acceptJoinTeamRequest.SendRequest(teammateUid);
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
                inviteText.text = teammateName+"邀请你加入小队";
            }else
            {
                inviteContent.gameObject.SetActive(false);
                joinTeamContent.gameObject.SetActive(true);
                infoContent.gameObject.SetActive(false);
                joinText.text = teammateName+"申请加入小队";
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

        public void JoinRequest(){
            isInvite = false;
        }

        protected override void CountDownRunning()
        {
            if(!isCountdown) return;
            countdown.value -= Time.deltaTime;
            joinCountdown.value -= Time.deltaTime;
            if(countdown.value <= 0){
                isCountdown = false;
                Destroy(gameObject);
            }
            if (joinCountdown.value <= 0)
            {
                isCountdown = false;
                Destroy(gameObject);
            }
        }

    }
}


