using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class BeatEnemyRequest : IRequest
{
    public override void Awake()
    {
        Name = "BeatEnemyRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.BeatEnemy;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log(mainPack.HitRegPack.Damage);
                    networkMediator.BeatEnemyCallback((EFloor)mainPack.HitRegPack.Floor, (EFloorPos)mainPack.HitRegPack.Pos);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }

}
