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

        public int playerSelfUid = 0;
        public int teamMasterPlayerUid = 0;

        public NetworkMediator(){
            Name = "NetworkMediator";
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            clientMgr = GameLoop.Instance.gameManager.ClientMgr;
            requestMgr = GameLoop.Instance.gameManager.RequestMgr;
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            EventMgr.AddListener<MainSceneBeginNotify>(OnMainSceneBegin);
        }

        void OnMainSceneBegin(MainSceneBeginNotify evt) => MainSceneBegin();
        void MainSceneBegin(){
            mainInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.MainInfoPanel).GetComponent<MainInfoPanelInfo>();

            partyCurrentStatePanelInfo = panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>();

            playerCurrentStatePanelInfo = panelMediator.GetPanel(EUIPanelType.PlayerCurrentStatePanel).GetComponent<PlayerCurrentStatePanelInfo>();

            playerInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.PlayerInfoPanel).GetComponent<PlayerInfoPanelInfo>();
        }

        public MainInfoPanelInfo mainInfoPanelInfo;
        public PartyCurrentStatePanelInfo partyCurrentStatePanelInfo;
        public PlayerCurrentStatePanelInfo playerCurrentStatePanelInfo;
        public PlayerInfoPanelInfo playerInfoPanelInfo;

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
        
        public void InvitedTeamCallback(int targetPlayerUid){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().InvitedTeamCallback(targetPlayerUid);
        }

        public void TeammateLeaveTeamCallback(int targetPlayerUid){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().TeammateLeaveTeamCallback(targetPlayerUid);
        }

        public void LeaveTeamCallback(){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().LeaveTeamCallback();
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
                        }
                    }

                    mainInfoPanelInfo.UpdatePlayerInfoCallback(_updatePlayerInfoPack);

                    partyCurrentStatePanelInfo.UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);

                    playerCurrentStatePanelInfo.UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);

                    playerInfoPanelInfo.UpdatePlayerInfoCallback(_updatePlayerInfoPack);
        }

        public void GetFriendsCallback(RepeatedField<FriendsPack> friendsPacks){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetFriendsCallback(friendsPacks);
        }

        public void GetTeammatesCallback(MainPack mainPack){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetTeammatesCallback(mainPack);
        }

        public void AcceptedInviteTeamCallback(int targetPlayerUid){
            panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().AcceptedInviteTeamCallback(targetPlayerUid);
        }

        public void GetFriendRequestCallback(RepeatedField<FriendsPack> friendsPacks){
            panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetFriendRequestCallback(friendsPacks);
        }

    }
}

