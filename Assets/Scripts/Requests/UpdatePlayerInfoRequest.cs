using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;
using ReTouchGunFire.Mediators;

public sealed class UpdatePlayerInfoRequest : IRequest
{
    public override void Awake()
    {
        Name = "UpdatePlayerInfoRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.UpdatePlayerInfo;
        base.Awake();
        EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);
        EventMgr.AddListener<MainSceneBeginNotify>(OnMainSceneBegin);
    }

    void OnMainSceneBegin(MainSceneBeginNotify evt) => MainSceneBegin();
    void MainSceneBegin(){
        mainInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.MainInfoPanel).GetComponent<MainInfoPanelInfo>();

        partyCurrentStatePanelInfo = panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>();

        playerCurrentStatePanelInfo = panelMediator.GetPanel(EUIPanelType.PlayerCurrentStatePanel).GetComponent<PlayerCurrentStatePanelInfo>();

        playerInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.PlayerInfoPanel).GetComponent<PlayerInfoPanelInfo>();
    }

    void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
    void PlayerInfoUpdate(){
        
        InvokeRepeating("SendRequest",0,1/10f);
    }

    MainInfoPanelInfo mainInfoPanelInfo;
    PartyCurrentStatePanelInfo partyCurrentStatePanelInfo;
    PlayerCurrentStatePanelInfo playerCurrentStatePanelInfo;
    PlayerInfoPanelInfo playerInfoPanelInfo;
    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    Debug.Log("Response");
                    UpdatePlayerInfoPack _updatePlayerInfoPack = new UpdatePlayerInfoPack();
                    foreach (UpdatePlayerInfoPack u in mainPack.UpdatePlayerInfoPack)
                    {
                        if (u.Uid == networkMediator.playerSelfUid)
                        {
                            _updatePlayerInfoPack = u;
                        }
                    }

                    mainInfoPanelInfo.UpdatePlayerInfoCallback(_updatePlayerInfoPack);

                    partyCurrentStatePanelInfo.UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);


                    playerCurrentStatePanelInfo.UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);

                    playerInfoPanelInfo.UpdatePlayerInfoCallback(_updatePlayerInfoPack);

                    
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("",3f);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    panelMediator.ShowNotifyPanel("",3f);
                break;
            
            }
        });
    }

    public void SendRequest(){
        MainPack mainPack = base.InitRequest();
        // Debug.Log("Send");
        base.UdpSendRequest(mainPack);
    }

}
