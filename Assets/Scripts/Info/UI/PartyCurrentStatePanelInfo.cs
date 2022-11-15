using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;
using Google.Protobuf.Collections;


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

        public Dictionary<int,TeammateBarInfo> teammateBarInfoDict = new Dictionary<int, TeammateBarInfo>();

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
            teammateBarInfoDict.Add(targetPlayerUid, teammateBar.GetComponent<TeammateBarInfo>());
        }

        public void AcceptedInviteTeamCallback(int targetPlayerUid){
            GameObject teammateBar = Instantiate(teammateBarTemplate, container);
            teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
            TeammateBarInfo teammateBarInfo = teammateBar.GetComponent<TeammateBarInfo>();
            teammateBarInfo.Accepted();
            teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo);
        }

        public void UpdatePlayerInfoCallback(RepeatedField<UpdatePlayerInfoPack> updatePlayerInfoPacks){
            foreach (UpdatePlayerInfoPack updatePlayerInfoPack in updatePlayerInfoPacks)
            {
                if (updatePlayerInfoPack.Uid == networkMediator.playerSelfUid)
                {
                    continue;
                }
                teammateBarInfoDict.TryGetValue(updatePlayerInfoPack.Uid, out TeammateBarInfo teammateBarInfo);
                teammateBarInfo.playerNameText.text = updatePlayerInfoPack.PlayerName;
                teammateBarInfo.armor.maxValue = updatePlayerInfoPack.MaxArmor;
                teammateBarInfo.armor.value = updatePlayerInfoPack.CurrentArmor;
                teammateBarInfo.health.maxValue = updatePlayerInfoPack.MaxHealth;
                teammateBarInfo.health.value = updatePlayerInfoPack.CurrentHealth;
            }
        }

    }
}


