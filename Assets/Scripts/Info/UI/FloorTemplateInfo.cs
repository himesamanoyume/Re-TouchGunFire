using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.PanelInfo{
    public sealed class FloorTemplateInfo : UIInfo
    {
        // [SerializeField] Transform Pos1_1;
        // [SerializeField] Transform Pos1_2;
        // [SerializeField] Transform Pos1_3;
        // [SerializeField] Transform Pos1_4;
        // [SerializeField] Transform Pos1_5;
        // [SerializeField] Transform Pos2_1;
        // [SerializeField] Transform Pos2_2;
        // [SerializeField] Transform Pos2_3;
        // [SerializeField] Transform Pos2_4;
        // [SerializeField] Transform Pos2_5;
        // [SerializeField] Transform Pos3_1;
        // [SerializeField] Transform Pos3_2;
        // [SerializeField] Transform Pos3_3;
        // [SerializeField] Transform Pos3_4;
        // [SerializeField] Transform Pos3_5;


        public GameObject enemyTemplate;

        public Dictionary<EFloorPos, Transform> PosDict = new Dictionary<EFloorPos, Transform>();

        private void Start() {
            Name = "FloorTemplateInfo";
            Init();
        }
        protected override void Init(){
            base.Init();
            for (int i = 0; i < transform.childCount; i++)
            {
                PosDict.Add((EFloorPos)i, transform.GetChild(i));
            }
            // panelMediator.FloorInitCallback(EUIPanelType.AttackArea1Panel);
            // Pos1_1 = transform.Find("1_1");
            // Pos1_2 = transform.Find("1_2");
            // Pos1_3 = transform.Find("1_3");
            // Pos1_4 = transform.Find("1_4");
            // Pos1_5 = transform.Find("1_5");
            // Pos2_1 = transform.Find("2_1");
            // Pos2_2 = transform.Find("2_2");
            // Pos2_3 = transform.Find("2_3");
            // Pos2_4 = transform.Find("2_4");
            // Pos2_5 = transform.Find("2_5");
            // Pos3_1 = transform.Find("3_1");
            // Pos3_2 = transform.Find("3_2");
            // Pos3_3 = transform.Find("3_3");
            // Pos3_4 = transform.Find("3_4");
            // Pos3_5 = transform.Find("3_5");
            // PosDict.Add(EFloorPos.Pos1_1, Pos1_1);
            // PosDict.Add(EFloorPos.Pos1_2, Pos1_2);
            // PosDict.Add(EFloorPos.Pos1_3, Pos1_3);
            // PosDict.Add(EFloorPos.Pos1_4, Pos1_4);
            // PosDict.Add(EFloorPos.Pos1_5, Pos1_5);
            // PosDict.Add(EFloorPos.Pos2_1, Pos2_1);
            // PosDict.Add(EFloorPos.Pos2_2, Pos2_2);
            // PosDict.Add(EFloorPos.Pos2_3, Pos2_3);
            // PosDict.Add(EFloorPos.Pos2_4, Pos2_4);
            // PosDict.Add(EFloorPos.Pos2_5, Pos2_5);
            // PosDict.Add(EFloorPos.Pos3_1, Pos3_1);
            // PosDict.Add(EFloorPos.Pos3_2, Pos3_2);
            // PosDict.Add(EFloorPos.Pos3_3, Pos3_3);
            // PosDict.Add(EFloorPos.Pos3_4, Pos3_4);
            // PosDict.Add(EFloorPos.Pos3_5, Pos3_5);
        }

        public void SpawnEnemy(EFloorPos[] args){
            if (args.Length <= 0)
            {
                return;
            }
            foreach (EFloorPos item in args)
            {
                GameObject enemy = Instantiate(enemyTemplate, PosDict[item]);
                enemy.AddComponent<EnemyInfo>();
                enemy.gameObject.SetActive(true);
            }
        }
    }
}

