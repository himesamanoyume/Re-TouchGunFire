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
    }

    

    void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
    void PlayerInfoUpdate(){
        InvokeRepeating("SendRequest",0,1/10f);
    }

    
    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    Debug.Log("Response");
                    networkMediator.UpdatePlayerInfoCallback(mainPack);
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
