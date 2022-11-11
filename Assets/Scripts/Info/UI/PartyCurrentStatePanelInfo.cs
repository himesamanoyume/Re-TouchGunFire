using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;


namespace ReTouchGunFire.PanelInfo{

    public class PartyCurrentStatePanelInfo : UIInfo
    {

        void Start()
        {
            Name = "PartyCurrentStatePanelInfo";
            Init();
        }

        public Transform container;
        public GameObject teammateBarTemplate;

        protected sealed override void Init()
        {
            base.Init();

            LoadTemplate();
            container = transform.Find("Point/Right/Container");
        }

        void LoadTemplate(){
            teammateBarTemplate = abMediator.SyncLoadABRes("prefabs","TeammateBar");
        }

        public void InvitedTeamCallback(int targetPlayerUid){
            GameObject teammateBar = Instantiate(teammateBarTemplate, container);
            teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
        }

        public void AcceptedInviteTeamCallback(){

        }

    }
}


