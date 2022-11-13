using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.PanelInfo;

public sealed class GetTeammatesRequest : IRequest
{
    public override void Awake()
    {
        Name = "GetTeammatesRequest";
        requestCode = RequestCode.Team;
        actionCode = ActionCode.GetTeammates;
        base.Awake();
    }

    public override void OnResponse(MainPack mainPack)
    {
        Loom.QueueOnMainThread(()=>{
            switch(mainPack.ReturnCode){
                case ReturnCode.Success:
                    //右下角显示有人拉我
                    Debug.Log("获取队伍信息成功");
                    panelMediator.GetPanel(EUIPanelType.FriendsPanel).GetComponent<FriendsPanelInfo>().GetTeammatesCallback(mainPack);
                    networkMediator.teamMasterPlayerUid = mainPack.PlayerInfoPack.Uid;
                break;
                case ReturnCode.Fail:
                    panelMediator.ShowNotifyPanel("获取队伍信息失败",3f);
                break;
                case ReturnCode.NotFound:
                    panelMediator.ShowNotifyPanel("你没有在队伍当中",3f);
                break;
                default:
                    panelMediator.ShowNotifyPanel("不正常情况",3f);
                break;
            
            }
        });
    }

    public void SendRequest(int senderUid){
        MainPack mainPack = base.InitRequest();
        
        base.TcpSendRequest(mainPack);
    }

}
