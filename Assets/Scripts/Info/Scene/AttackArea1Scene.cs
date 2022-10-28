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

        panelMediator.PushPanel(EUIPanelType.AttackArea1Panel, EUILevel.Level2, false, (GameObject obj)=>{
            obj.AddComponent<AttackArea1PanelInfo>().currentLevel = EUILevel.Level2;
        });
        panelMediator.PushPanel(EUIPanelType.BattleGunInfoPanel,EUILevel.Level3, false, (GameObject obj)=>{
            obj.AddComponent<BattleGunInfoPanelInfo>().currentLevel = EUILevel.Level3;
        });
        panelMediator.PushPanel(EUIPanelType.BattleLittleMenuPanel,EUILevel.Level3, false, (GameObject obj)=>{
            obj.AddComponent<BattleLittleMenuPanelInfo>().currentLevel = EUILevel.Level3;
        });
        panelMediator.PushPanel(EUIPanelType.PlayerCurrentStatePanel,EUILevel.Level3, false, (GameObject obj)=>{
            obj.AddComponent<PlayerCurrentStatePanelInfo>().currentLevel = EUILevel.Level3;
        });
        panelMediator.MovePanelLevel(EUIPanelType.PlayerInfoPanel,EUILevel.Level3);
        panelMediator.MovePanelLevel(EUIPanelType.MainInfoPanel,EUILevel.Level3);
        panelMediator.MovePanelLevel(EUIPanelType.PlayerPropsPanel,EUILevel.Level1);
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnEnd()
    {
        panelMediator.DestroyPanel(EUIPanelType.AttackArea1Panel);
        panelMediator.DestroyPanel(EUIPanelType.BattleGunInfoPanel);
        panelMediator.DestroyPanel(EUIPanelType.BattleLittleMenuPanel);
        panelMediator.DestroyPanel(EUIPanelType.PlayerCurrentStatePanel);
    }
}
