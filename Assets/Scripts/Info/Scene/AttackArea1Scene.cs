using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class AttackArea1Scene : SceneInfo
{
    public AttackArea1Scene(SceneMediator sceneMediator) : base(sceneMediator){
        Name = "AttackArea1Scene";
    }

    public PanelMediator panelMediator;

    public override void OnBegin()
    {
        panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
        panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
        EventMgr.Broadcast(GameEvents.RestorePanelNotify);
        // EventMgr.Broadcast(GameEvents.ShowLoadingPanelNotify);

        panelMediator.PushPanel(EUIPanelType.AttackAreaPanel, EUILevel.Level2, false, (GameObject obj)=>{
            obj.AddComponent<AttackAreaPanelInfo>().currentLevel = EUILevel.Level2;
        });
        
        EventMgr.Broadcast(GameEvents.ShowBattleLittleMenuPanelNotify);
        panelMediator.MovePanelLevel(EUIPanelType.PlayerInfoPanel,EUILevel.Level3);
        panelMediator.MovePanelLevel(EUIPanelType.MainInfoPanel,EUILevel.Level3);
        panelMediator.MovePanelLevel(EUIPanelType.PlayerCurrentStatePanel,EUILevel.Level3);
        panelMediator.MovePanelLevel(EUIPanelType.BattleGunInfoPanel,EUILevel.Level3);
        // panelMediator.MovePanelLevel(EUIPanelType.PlayerPropsPanel,EUILevel.Level1);
        EventMgr.Broadcast(GameEvents.CloseLoadingPanelNotify);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnEnd()
    {
        Debug.Log("End");
        panelMediator.DestroyPanel(EUIPanelType.AttackAreaPanel);
    }
}
