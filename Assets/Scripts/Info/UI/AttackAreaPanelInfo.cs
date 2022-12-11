using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.PanelInfo{
    public sealed class AttackAreaPanelInfo : BaseAttackAreaPanelInfo
    {
        
        private void Start() {
            Name = "AttackArea1PanelInfo";
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
