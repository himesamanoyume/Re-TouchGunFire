using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;

public sealed class InitPlayerInfoRequest : IRequest
{
    public override void Awake() {
        Name = "InitPlayerInfoRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.InitPlayerInfo;
        base.Awake();
        
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    networkMediator.playerSelfUid = mainPack.PlayerInfoPack.Uid;
                    //赋值装备与武器
                    // Debug.Log(mainPack.PlayerInfoPack.EquipmentPacks);
                    networkMediator.UpdatePlayerGunInfoCallback(mainPack.PlayerInfoPack.GunPacks);
                    networkMediator.UpdatePlayerEquipmentInfoCallback(mainPack.PlayerInfoPack.EquipmentPacks);
                    //end
                    EventMgr.Broadcast(GameEvents.PlayerInfoUpdateNotify); 
                break;
                case ReturnCode.Fail:
                    
                break;
                case ReturnCode.ReturnNone:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                    // Debug.LogError("不正常情况");
                break;
            }
        });
    }

    public void SendRequest()
    {
        MainPack mainPack = base.InitRequest();
        
        base.TcpSendRequest(mainPack);
    }
}
