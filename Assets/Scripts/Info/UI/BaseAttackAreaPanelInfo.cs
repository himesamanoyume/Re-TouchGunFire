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

            EventMgr.AddListener<PlayerShootingNotify>(OnPlayerShooting);
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

        private void FixedUpdate() {
            // ShotRay();
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

        void OnPlayerShooting(PlayerShootingNotify evt) => ShotRay();
        void ShotRay(){

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hit = Physics.RaycastAll(ray.origin, ray.direction);
                
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.DrawLine(ray.origin, hit[i].point, Color.green);
                Debug.Log(hit[i].collider.name);
            }
        
            // if(Input.GetMouseButton(0)){
            //     //这部分之后应当转移到射击部分的逻辑中 射击时触发事件 射线检测的发射则在监听的委托当中
            //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //     RaycastHit[] hit = Physics.RaycastAll(ray.origin, ray.direction);
                
            //     for (int i = 0; i < hit.Length; i++)
            //     {
            //         Debug.DrawLine(ray.origin, hit[i].point, Color.green);
            //         Debug.Log(hit[i].collider.name);
            //     }
            // }

        }
    }
}

