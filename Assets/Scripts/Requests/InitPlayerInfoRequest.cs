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

    PlayerInfo playerInfo;

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();
                    playerInfo.uid = mainPack.PlayerInfoPack.Uid;
                    playerInfo.playerName = mainPack.PlayerInfoPack.PlayerName;
                    playerInfo.level = mainPack.PlayerInfoPack.Level;
                    playerInfo.currentExp = mainPack.PlayerInfoPack.CurrentExp;
                    playerInfo.diamond = mainPack.PlayerInfoPack.Diamond;
                    playerInfo.coin = mainPack.PlayerInfoPack.Coin;
                    //赋值装备与武器

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
