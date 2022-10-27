using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.PanelInfo{
    public sealed class AttackArea1PanelInfo : BaseAttackAreaPanelInfo
    {
        
        private void Start() {
            Name = "AttackArea1PanelInfo";
            currentLevel = EUILevel.Level2;
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            
            // EventMgr.Broadcast(GameEvents.CloseLoadingPanelNotify);
        }

        protected sealed override void Update()
        {
            base.Update();
            
        }
    }
}
