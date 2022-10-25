using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.PanelInfo{
    public abstract class BaseAttackAreaPanelInfo : UIInfo
    {
        public Transform enemyPart;
        public Transform floor1;
        public Transform floor2;
        public Transform floor3;
        protected override void Init(){
            base.Init();
            enemyPart = transform.Find("Point/MiddleCenter/BattlePart/EnemyPart");
            floor1 = enemyPart.Find("Floor1");
            floor2 = enemyPart.Find("Floor2");
            floor3 = enemyPart.Find("Floor3");
        }

        protected virtual void Update() {
            
        }
        
    }
}

