using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mediators;

public class InitPlayerInfoRequest : IRequest
{
    public override void Awake() {
        Name = "InitPlayerInfoRequest";
        requestCode = RequestCode.User;
        actionCode = ActionCode.InitPlayerInfo;
        base.Awake();
        playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();
    }

    PlayerInfo playerInfo;

    public override void OnResponse(MainPack mainPack)
    {
        switch(mainPack.ReturnCode){
            case ReturnCode.Success:
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
                Debug.LogError("不正常情况");
            break;
        }
    }

    public void SendRequest()
    {
        MainPack mainPack = new MainPack();
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        mainPack.Uid = networkMediator.uid;
        
        base.TcpSendRequest(mainPack);
    }
}
