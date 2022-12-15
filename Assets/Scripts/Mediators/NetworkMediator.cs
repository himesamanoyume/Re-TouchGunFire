using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mgrs;
using ReTouchGunFire.PanelInfo;
using Google.Protobuf.Collections;

namespace ReTouchGunFire.Mediators{
    public sealed class NetworkMediator : IMediator
    {
        public ClientMgr clientMgr;
        public RequestMgr requestMgr;
        public PanelMediator panelMediator;
        SceneMediator sceneMediator;
        [SerializeField] PlayerInfo playerInfo;

        public int playerSelfUid = 0;
        public int teamMasterPlayerUid = 0;
        public bool teammateAllReady = false;

        public NetworkMediator(){
            Name = "NetworkMediator";
        }

        private void Start() {
            Init();
        }

        public PlayerInfo GetPlayerInfo{
            get{ return playerInfo;}
        }

        public override void Init()
        {
            clientMgr = GameLoop.Instance.gameManager.ClientMgr;
            requestMgr = GameLoop.Instance.gameManager.RequestMgr;
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            sceneMediator = GameLoop.Instance.GetMediator<SceneMediator>();
            playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();
            EventMgr.AddListener<MainSceneBeginNotify>(OnMainSceneBegin);
        }

        void OnMainSceneBegin(MainSceneBeginNotify evt) => MainSceneBegin();
        void MainSceneBegin(){
            mainInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.MainInfoPanel).GetComponent<MainInfoPanelInfo>();

            partyCurrentStatePanelInfo = panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>();

            playerCurrentStatePanelInfo = panelMediator.GetPanel(EUIPanelType.PlayerCurrentStatePanel).GetComponent<PlayerCurrentStatePanelInfo>();

            playerInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.PlayerInfoPanel).GetComponent<PlayerInfoPanelInfo>();

            mainMenuPanelInfo = panelMediator.GetPanel(EUIPanelType.MainMenuPanel).GetComponent<MainMenuPanelInfo>();
        }

        [SerializeField] MainInfoPanelInfo mainInfoPanelInfo;
        [SerializeField] PartyCurrentStatePanelInfo partyCurrentStatePanelInfo;
        [SerializeField] PlayerCurrentStatePanelInfo playerCurrentStatePanelInfo;
        [SerializeField] PlayerInfoPanelInfo playerInfoPanelInfo;
        [SerializeField] MainMenuPanelInfo mainMenuPanelInfo;

        public void TcpSend(MainPack mainPack){
            clientMgr.TcpSend(mainPack);
        }

        public void UdpSend(MainPack mainPack){
            clientMgr.UdpSend(mainPack);
        }

        public void AddRequest(IRequest request)
        {
            requestMgr.AddRequest(request);
        }

        public void RemoveRequest(IRequest request)
        {
            requestMgr.RemoveRequest(request);
        }

        public void HandleResponse(MainPack mainPack){
            requestMgr.HandleResponse(mainPack);
        }
        
        public void InvitedTeamCallback(int targetPlayerUid, string targetPlayerName){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().InvitedTeamCallback(targetPlayerUid, targetPlayerName);
        }

        public void TeammateLeaveTeamCallback(int targetPlayerUid){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().TeammateLeaveTeamCallback(targetPlayerUid);
        }

        public void LeaveTeamCallback(){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().LeaveTeamCallback();

            mainMenuPanelInfo.LeaveTeamCallback();
        }

        public void SearchFriendCallback(MainPack mainPack){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().SearchFriendCallback(mainPack);
        }

        public void UpdatePlayerInfoCallback(MainPack mainPack){
            UpdatePlayerInfoPack _updatePlayerInfoPack = new UpdatePlayerInfoPack();
            foreach (UpdatePlayerInfoPack u in mainPack.UpdatePlayerInfoPack)
            {
                if (u.Uid == playerSelfUid)
                {
                    _updatePlayerInfoPack = u;
                    teamMasterPlayerUid = _updatePlayerInfoPack.TeamMasterUid;
                }
            }

            playerInfo.UpdatePlayerInfo(_updatePlayerInfoPack);

            if (teamMasterPlayerUid != 0)
            {
                if (teamMasterPlayerUid != playerSelfUid)
                {
                    mainMenuPanelInfo.IsInTheTeam(true);
                }else
                {
                    mainMenuPanelInfo.PlayerJoinTeamCallback();
                }
            }else
            {
                mainMenuPanelInfo.IsInTheTeam(false);
            }

            partyCurrentStatePanelInfo.UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);

            // playerCurrentStatePanelInfo.UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);
        }

        public void PlayerJoinTeamCallback(int targetPlayerUid, string targetPlayerName){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().PlayerJoinTeamCallback(targetPlayerUid, targetPlayerName);

            mainMenuPanelInfo.PlayerJoinTeamCallback();
        }

        public void GetFriendsCallback(RepeatedField<FriendsPack> friendsPacks){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetFriendsCallback(friendsPacks);
        }

        public void GetTeammatesCallback(MainPack mainPack){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetTeammatesCallback(mainPack);
        }

        public void AcceptedInviteTeamCallback(int targetPlayerUid, string targetPlayerName){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().AcceptedInviteTeamCallback(targetPlayerUid, targetPlayerName);
        }

        public void GetFriendRequestCallback(RepeatedField<FriendsPack> friendsPacks){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetFriendRequestCallback(friendsPacks);
        }

        public void UpdatePlayerGunInfoCallback(RepeatedField<GunPack> gunPacks){
            playerInfo.UpdatePlayerGunInfoCallback(gunPacks);
        }

        public void UpdatePlayerEquipmentInfoCallback(RepeatedField<EquipmentPack> equipmentPacks){
            playerInfo.UpdatePlayerEquipmentInfoCallback(equipmentPacks);
        }

        public List<ItemInfo> GetItemInfoList(EItemList eItemList){
            return playerInfo.GetItemInfoList(eItemList);
        }

        // public void RefuseJoinTeamCallback(int targetPlayerUid){
        //     panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().RefuseJoinTeamCallback(targetPlayerUid);
        // }

        public void StartAttackCallback(int areaNumber){
            mainMenuPanelInfo.StartAttackCallback(areaNumber);

            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().StartAttackCallback();

            if (teamMasterPlayerUid != playerSelfUid)
            {
                mainMenuPanelInfo.CancelReadyAttackCallback();
            }
        }

        public void AttackLeaveCallback(){
            panelMediator.GetPanel(EUIPanelType.BattleLittleMenuPanel).GetComponent<BattleLittleMenuPanelInfo>().AttackLeaveCallback();
            mainMenuPanelInfo.AttackEndCallback();
        }

        [SerializeField] AttackAreaPanelInfo attackAreaPanelInfo = null;
        public void UpdateAttackingInfoCallback(RepeatedField<EnemyPack> enemyPacks){
            try
            {
                if (attackAreaPanelInfo == null)
                {
                    attackAreaPanelInfo = panelMediator.GetPanel(EUIPanelType.AttackAreaPanel).GetComponent<AttackAreaPanelInfo>();
                }
                attackAreaPanelInfo.UpdateAttackingInfoCallback(enemyPacks);
            }
            catch
            {
               
            }
            
        }

        public void HitRegCallback(float dmg, EFloor floor, EFloorPos pos, bool isHeadshot, bool isCrit){
            if (attackAreaPanelInfo == null)
            {
                if (sceneMediator.SceneLog() != "MainScene")
                {
                    attackAreaPanelInfo = panelMediator.GetPanel(EUIPanelType.AttackAreaPanel).GetComponent<AttackAreaPanelInfo>();
                    attackAreaPanelInfo.HitRegCallback(dmg, floor, pos, isHeadshot, isCrit);
                } 
            }else{
                attackAreaPanelInfo.HitRegCallback(dmg, floor, pos, isHeadshot, isCrit);
            }
        }

        public void BeatEnemyCallback(EFloor floor, EFloorPos pos){
            panelMediator.GetPanel(EUIPanelType.AttackAreaPanel).GetComponent<BaseAttackAreaPanelInfo>().BeatEnemyCallback(floor, pos);
        }

        public void AttackEndCallback(){
            panelMediator.GetPanel(EUIPanelType.BattleLittleMenuPanel).GetComponent<BattleLittleMenuPanelInfo>().AttackLeaveCallback();

            mainMenuPanelInfo.AttackEndCallback();
        }

        public void ReadyAndCancelReadyAttackCallback(bool isReady, int teammateUid){
            teammateAllReady = panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().ReadyAndCancelReadyAttackCallback(isReady, teammateUid);
            mainMenuPanelInfo.ReadyAndCancelReadyAttackCallback();
        }

        public void ReadyAttackCallback(){
            mainMenuPanelInfo.ReadyAttackCallback();
        }

        public void CancelReadyAttackCallback(){
            mainMenuPanelInfo.CancelReadyAttackCallback();
        }

    }
}

