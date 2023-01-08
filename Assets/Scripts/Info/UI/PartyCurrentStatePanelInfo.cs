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

        [SerializeField] Transform container;
        [SerializeField] GameObject teammateBarTemplate;

        public Dictionary<int,TeammateBarInfo> teammateBarInfoDict = new Dictionary<int, TeammateBarInfo>();

        protected sealed override void Init()
        {
            base.Init();

            LoadTemplate();
            container = transform.Find("Point/Right/Container");
            EventMgr.Broadcast(GameEvents.MainSceneBeginNotify);
        }

        void LoadTemplate(){
            teammateBarTemplate = abMediator.SyncLoadABRes("prefabs","TeammateBar");
        }

        public void InvitedTeamCallback(int targetPlayerUid, string targetPlayerName){
            // Debug.Log("InvitedTeamCallback");
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                
            }else{
                teammateBarInfoDict.Remove(targetPlayerUid);
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
            }
            
        }

        public void AcceptedInviteTeamCallback(int targetPlayerUid, string targetPlayerName){
            // Debug.Log("AcceptedInviteTeamCallback");
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                teammateBarInfoDict.Remove(targetPlayerUid);
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
                teammateBarInfo1.Accepted();
            }else{
                teammateBarInfoDict.Remove(targetPlayerUid);
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
                teammateBarInfo1.Accepted();
            }
            
        }

        public void AcceptInviteTeamCallback(int targetPlayerUid){
            // Debug.Log("AcceptInviteTeamCallback");
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                teammateBarInfo.Accepted();
            } 
        }

        public void TeammateLeaveTeamCallback(int targetPlayerUid){
            // Debug.Log("TeammateLeaveTeamCallback");
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                Destroy(teammateBarInfo.gameObject);
                teammateBarInfoDict.Remove(targetPlayerUid);
            } 
        }

        public void PlayerJoinTeamCallback(int targetPlayerUid, string targetPlayerName){
            // Debug.Log("PlayerJoinTeamCallback");
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
            
                
            }else{
                teammateBarInfoDict.Remove(targetPlayerUid);
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfo1.JoinRequest();
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
            }
            
        }

        public void LeaveTeamCallback(){
            for (int i = 0; i < container.childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
            teammateBarInfoDict.Clear();
        }

        public void UpdatePlayerInfoCallback(RepeatedField<UpdatePlayerInfoPack> updatePlayerInfoPacks){
            foreach (UpdatePlayerInfoPack updatePlayerInfoPack in updatePlayerInfoPacks)
            {
                if (updatePlayerInfoPack.Uid == networkMediator.playerSelfUid)
                {
                    continue;
                }
                try
                {
                   
                    teammateBarInfoDict.TryGetValue(updatePlayerInfoPack.Uid, out TeammateBarInfo teammateBarInfo);
                    if (teammateBarInfo != null)
                    {
                        teammateBarInfo.playerNameText.text = updatePlayerInfoPack.PlayerName;
                        teammateBarInfo.teammateName = updatePlayerInfoPack.PlayerName;
                        teammateBarInfo.armor.maxValue = updatePlayerInfoPack.MaxArmor;
                        teammateBarInfo.armor.value = updatePlayerInfoPack.CurrentArmor;
                        teammateBarInfo.health.maxValue = updatePlayerInfoPack.MaxHealth;
                        teammateBarInfo.health.value = updatePlayerInfoPack.CurrentHealth;
                    }else{

                        // Debug.Log("UpdatePlayerInfoCallback");
                        teammateBarInfoDict.Remove(updatePlayerInfoPack.Uid);
                        GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                        teammateBar.AddComponent<TeammateBarInfo>().teammateUid = updatePlayerInfoPack.Uid;
                        TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                        teammateBarInfoDict.Add(updatePlayerInfoPack.Uid, teammateBarInfo1);
                        teammateBarInfo1.Accepted();
                    }
                }
                catch 
                {
                    
                }
                
            }
        }

        public bool ReadyAndCancelReadyAttackCallback(bool isReady, int teammateUid){
            if (teammateBarInfoDict.TryGetValue(teammateUid, out TeammateBarInfo teammateBarInfo))
            {
                teammateBarInfo.BeReady(isReady);
            }

            foreach (TeammateBarInfo item in teammateBarInfoDict.Values)
            {
                if (!item.isReady)
                {
                    return false;
                }
            }
            return true;
        }

        public void StartAttackCallback(){
            foreach (TeammateBarInfo item in teammateBarInfoDict.Values)
            {
                item.BeReady(false);
            }
        }

    }
}


