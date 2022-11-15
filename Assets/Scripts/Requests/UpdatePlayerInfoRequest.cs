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
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    panelMediator.GetPanel(EUIPanelType.PartyCurrentStatePanel).GetComponent<PartyCurrentStatePanelInfo>().UpdatePlayerInfoCallback(mainPack.UpdatePlayerInfoPack);
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
        base.UdpSendRequest(mainPack);
    }

}
