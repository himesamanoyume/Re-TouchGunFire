using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;
using ReTouchGunFire.Mediators;

public sealed class RegenerationRequest : IRequest
{
    public override void Awake()
    {
        Name = "RegenerationRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.Regeneration;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log("Response");
                    
                break;
                case ReturnCode.Fail:
                    // Debug.Log("RegenerationRequest "+mainPack.ReturnCode);
                break;
                default:
                    // Debug.Log(mainPack.ReturnCode);
                    // Debug.Log("RegenerationRequest "+mainPack.ReturnCode);
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
