using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf.Collections;
using SocketProtocol;

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

        [SerializeField] UpdateAttackingInfoRequest updateAttackingInfoRequest;
        [SerializeField] HitRegRequest hitRegRequest;
        [SerializeField] BattleGunInfoPanelInfo battleGunInfoPanelInfo;

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

            updateAttackingInfoRequest = (UpdateAttackingInfoRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.UpdateAttackingInfo);
            hitRegRequest = (HitRegRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.HitReg);
            battleGunInfoPanelInfo = panelMediator.GetPanel(EUIPanelType.BattleGunInfoPanel).GetComponent<BattleGunInfoPanelInfo>();

            EventMgr.AddListener<PlayerShootingRayNotify>(OnPlayerShootingRay);
            // EventMgr.AddListener<StartAttackNotify>(OnStartAttack);
            if (networkMediator.teamMasterPlayerUid == networkMediator.GetPlayerInfo.Uid || networkMediator.teamMasterPlayerUid == 0)
            {
                InvokeRepeating("OnStartAttack", 0, 1f/10f);
            }
        }

        // void OnStartAttack(StartAttackNotify evt) => StartAttack();
        // void StartAttack(){
            
        // }

        private void OnDestroy() {
            EventMgr.RemoveListener<PlayerShootingRayNotify>(OnPlayerShootingRay);
        }

        void OnStartAttack(){
            updateAttackingInfoRequest.SendRequest();
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
                EnemyInfo enemyInfo = hit[i].collider.GetComponent<EnemyInfo>();
                if (i==0)
                {
                    hitRegRequest.SendRequest((int)enemyInfo.floor, (int)enemyInfo.floorPos, battleGunInfoPanelInfo.isMainGun);
                }else
                {
                    hitRegRequest.SendRequest((int)enemyInfo.floor, (int)enemyInfo.floorPos, battleGunInfoPanelInfo.isMainGun, true);
                }
                EventMgr.Broadcast(GameEvents.PlayerRayHitEnemy);
                // Debug.Log(hit[i].collider.name);
            }
        }

        public void UpdateAttackingInfoCallback(RepeatedField<EnemyPack> enemyPacks){
            // Debug.Log("UpdateAttackingInfo1");
            foreach (EnemyPack item in enemyPacks)
            {
                switch((EFloor)item.Floor){
                case EFloor.Floor1:
                    floor1Info.UpdateAttackingInfo(item);
                break;
                case EFloor.Floor2:
                    floor2Info.UpdateAttackingInfo(item);
                break;
                case EFloor.Floor3:
                    floor3Info.UpdateAttackingInfo(item);
                break;
                }
            }
            
        }

        public void BeatEnemyCallback(EFloor floor, EFloorPos pos){
            switch(floor){
                case EFloor.Floor1:
                    floor1Info.BeatEnemy(pos);
                break;
                case EFloor.Floor2:
                    floor2Info.BeatEnemy(pos);
                break;
                case EFloor.Floor3:
                    floor3Info.BeatEnemy(pos);
                break;
            }
        }
    }
}

