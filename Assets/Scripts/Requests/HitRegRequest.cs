using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class HitRegRequest : IRequest
{
    public override void Awake()
    {
        Name = "HitRegRequest";
        requestCode = RequestCode.Gaming;
        actionCode = ActionCode.HitReg;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    // Debug.Log(mainPack.HitRegPack.Damage);
                    networkMediator.HitRegCallback(mainPack.HitRegPack.Damage, (EFloor)mainPack.HitRegPack.Floor, (EFloorPos)mainPack.HitRegPack.Pos);
                break;
                case ReturnCode.Fail:
                    Debug.Log("伤害丢失");
                    // panelMediator.ShowNotifyPanel("获取队伍信息失败",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            }
        });
    }

    public void SendRequest(int floor, int floorPos, bool isMainGun, bool isStrike = false){
        MainPack mainPack = base.InitRequest();
        HitRegPack hitRegPack = new HitRegPack();
        hitRegPack.HitSenderUid = networkMediator.playerSelfUid;
        hitRegPack.Floor = floor;
        hitRegPack.Pos = floorPos;
        hitRegPack.IsMainGun = isMainGun;
        hitRegPack.IsStrike = isStrike;
        mainPack.HitRegPack = hitRegPack;
        base.UdpSendRequest(mainPack);
    }

}
