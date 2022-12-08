using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.PanelInfo{
    public abstract class BaseAttackAreaPanelInfo : UIInfo
    {
        [SerializeField] Transform enemyPart;
        [SerializeField] Transform floor1;
        [SerializeField] Transform floor2;
        [SerializeField] Transform floor3;

        [SerializeField] protected FloorTemplateInfo floor1Info;
        [SerializeField] protected FloorTemplateInfo floor2Info;
        [SerializeField] protected FloorTemplateInfo floor3Info;

        [SerializeField] GameObject enemyTemplate;

        protected override void Init(){
            base.Init();
            enemyPart = transform.Find("Point/MiddleCenter/BattlePart/EnemyPart");
            floor1 = enemyPart.Find("Floor1");
            floor2 = enemyPart.Find("Floor2");
            floor3 = enemyPart.Find("Floor3");

            enemyTemplate = enemyPart.Find("Enemy").gameObject;

            floor1Info = floor1.GetChild(0).gameObject.AddComponent<FloorTemplateInfo>();
            floor1Info.enemyTemplate = enemyTemplate;
            floor2Info = floor2.GetChild(0).gameObject.AddComponent<FloorTemplateInfo>();
            floor2Info.enemyTemplate = enemyTemplate;
            floor3Info = floor3.GetChild(0).gameObject.AddComponent<FloorTemplateInfo>();
            floor3Info.enemyTemplate = enemyTemplate;

            

            EventMgr.AddListener<PlayerShootingRayNotify>(OnPlayerShootingRay);
        }

        Vector3 currentRot;

        protected virtual void Update() {
            currentRot = enemyPart.localRotation.eulerAngles;
            currentRot.y = 0;

            if(currentRot.x >= 270 && currentRot.x <=360){
                currentRot.x = 360;
            }
            enemyPart.localRotation = Quaternion.Euler(currentRot);
        }

        float rotSpeed = 80;
        private void OnMouseDrag() {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            
            if(currentRot.z <= 270 && currentRot.z >= 90){
                enemyPart.Rotate(Vector3.forward, rotX);
                enemyPart.Rotate(Vector3.left, rotY);
            }else{
                enemyPart.Rotate(Vector3.forward, rotX);
                enemyPart.Rotate(Vector3.left, -rotY);
            }
        }

        void OnPlayerShootingRay(PlayerShootingRayNotify evt) => ShotRay();
        void ShotRay(){

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.RaycastAll(ray.origin, ray.direction);
                
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.DrawLine(ray.origin, hit[i].point, Color.green);
                EventMgr.Broadcast(GameEvents.PlayerRayHitEnemy);
                // Debug.Log(hit[i].collider.name);
            }
        }

        public void FloorSpawnEnemyCallback(EFloor eFloor, EFloorPos[] eFloorPos){
            switch(eFloor){
                case EFloor.Floor1:
                    floor1Info.SpawnEnemy(eFloorPos);
                break;
                case EFloor.Floor2:
                    floor2Info.SpawnEnemy(eFloorPos);
                break;
                case EFloor.Floor3:
                    floor3Info.SpawnEnemy(eFloorPos);
                break;
            }
        }

        
    }
}

