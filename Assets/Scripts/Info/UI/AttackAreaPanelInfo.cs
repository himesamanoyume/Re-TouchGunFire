// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// namespace ReTouchGunFire.PanelInfo{
//     public sealed class AttackAreaPanelInfo : BaseAttackAreaPanelInfo
//     {
        
//         private void Start() {
//             Name = "AttackArea1PanelInfo";
//             Init();
//         }


//         Transform damagePart;
//         [SerializeField] GameObject textTemplate;
//         [SerializeField] Transform templatePos;

//         List<DamageTextInfo> damageTextList = new List<DamageTextInfo>();
//         [SerializeField] int index = 0;

//         protected sealed override void Init()
//         {
//             base.Init();
//             // EventMgr.Broadcast(GameEvents.CloseLoadingPanelNotify);
//             damagePart = transform.Find("Point/MiddleCenter/DamagePart");
//             templatePos = damagePart.Find("TextTemplate");
//             textTemplate = templatePos.gameObject;
//             for (int i = 1; i < damagePart.childCount; i++)
//             {
//                 damageTextList.Add(damagePart.GetChild(i).gameObject.AddComponent<DamageTextInfo>());
//             }
//         }

//         protected sealed override void Update()
//         {
//             base.Update();
            
//         }

//         public void HitRegCallback(float dmg, EFloor floor, EFloorPos pos, bool isHeadshot, bool isCrit){
//             if (index == damageTextList.Count - 1)
//             {
//                 damageTextList[index].InitInfo(dmg, templatePos, GetEnemyPos(floor, pos), isHeadshot, isCrit);
//                 index = 0;
//             }else
//             {
//                 damageTextList[index].InitInfo(dmg, templatePos, GetEnemyPos(floor, pos), isHeadshot, isCrit);
//                 index++;
//             }
            
//         }

        

//         Transform GetEnemyPos(EFloor floor, EFloorPos pos){
//             switch(floor){
//                 case EFloor.Floor1:
//                     return floor1Info.PosDict[pos];
//                 case EFloor.Floor2:
//                     return floor2Info.PosDict[pos];
//                 case EFloor.Floor3:
//                     return floor3Info.PosDict[pos];
//             }
//             return null;
//         }
//     }

    
// }
