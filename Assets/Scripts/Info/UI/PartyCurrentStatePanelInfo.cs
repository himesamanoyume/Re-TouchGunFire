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
            EventMgr.Broadcast(GameEvents.MainSceneBeginNotify);
        }

        void LoadTemplate(){
            teammateBarTemplate = abMediator.SyncLoadABRes("prefabs","TeammateBar");
        }

        public void InvitedTeamCallback(int targetPlayerUid, string targetPlayerName){
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                teammateBarInfoDict.Remove(targetPlayerUid);
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
            }else{
                
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
            }
            
        }

        public void AcceptedInviteTeamCallback(int targetPlayerUid, string targetPlayerName){
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
                
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
                teammateBarInfo1.Accepted();
            }
            
        }

        // public void RefuseJoinTeamCallback(int targetPlayerUid){
        //     teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
        //     if (teammateBarInfo != null)
        //     {
        //         Destroy(teammateBarInfo.gameObject);
        //         teammateBarInfoDict.Remove(targetPlayerUid);
        //     } 
        // }

        public void AcceptInviteTeamCallback(int targetPlayerUid){
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                teammateBarInfo.Accepted();
            } 
        }

        public void TeammateLeaveTeamCallback(int targetPlayerUid){
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                Destroy(teammateBarInfo.gameObject);
                teammateBarInfoDict.Remove(targetPlayerUid);
            } 
        }

        public void PlayerJoinTeamCallback(int targetPlayerUid, string targetPlayerName){
            teammateBarInfoDict.TryGetValue(targetPlayerUid, out TeammateBarInfo teammateBarInfo);
            if (teammateBarInfo != null)
            {
                teammateBarInfoDict.Remove(targetPlayerUid);
                GameObject teammateBar = Instantiate(teammateBarTemplate, container);
                teammateBar.AddComponent<TeammateBarInfo>().teammateUid = targetPlayerUid;
                TeammateBarInfo teammateBarInfo1 = teammateBar.GetComponent<TeammateBarInfo>();
                teammateBarInfo1.teammateName = targetPlayerName;
                teammateBarInfo1.JoinRequest();
                teammateBarInfoDict.Add(targetPlayerUid, teammateBarInfo1);
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

    }
}


