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

        Vector3 currentRot;

        protected virtual void Update() {
            currentRot = enemyPart.localRotation.eulerAngles;
            currentRot.y = 0;
            
            // if(currentRot.z > 10) currentRot.z = 10;
            // if(currentRot.z < 0) currentRot.z = 0;
            // Debug.Log("Update");
            // if(currentRot.x > 100){
            //     currentRot.x = 100;
            //     Debug.Log(">");
            // }
            if(currentRot.x >= 270 && currentRot.x <=360){
                currentRot.x = 360;
                // Debug.Log("<");
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
                // Debug.Log("one");
            
            // }else if(currentRot.z >= 70 && currentRot.z <= 120){
            //     enemyPart.Rotate(Vector3.forward, rotX);
            //     enemyPart.Rotate(Vector3.up, -rotY);
            }else{
                //
                // Debug.Log("two");
                enemyPart.Rotate(Vector3.forward, rotX);
                enemyPart.Rotate(Vector3.left, -rotY);
                //
            }
            
            
            // enemyPart.Rotate(Vector3.forward, rotX);
            // enemyPart.Rotate(Vector3.left, -rotY);

        }
        
    }
}

