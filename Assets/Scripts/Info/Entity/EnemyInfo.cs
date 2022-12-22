// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using SocketProtocol;

// public sealed class EnemyInfo : EntityInfo
// {
//     public EFloor floor = EFloor.Null;
//     public EFloorPos floorPos = EFloorPos.Null;
//     [SerializeField] Slider healthSlider;
//     [SerializeField] Slider armorSlider;
//     [SerializeField] Text enemyName;
//     [SerializeField] string enemyNameStr;
//     [SerializeField] float currentArmor;
//     [SerializeField] float maxArmor;
//     [SerializeField] float currentHealth;
//     [SerializeField] float maxHealth;

//     private void Start() {
//         Init();
//     }

//     protected override void Init()
//     {
//         base.Init();
//         healthSlider = transform.Find("ImagePart/HealthSlider").GetComponent<Slider>();
//         armorSlider = transform.Find("ImagePart/ArmorSlider").GetComponent<Slider>();
//         enemyName = transform.Find("InfoPart/Text").GetComponent<Text>();
//     }

//     public void UpdateAttackingInfo(EnemyPack enemyPack){
//         floor = (EFloor)enemyPack.Floor;
//         floorPos = (EFloorPos)enemyPack.Pos;
//         try
//         {
//             enemyName.text = enemyPack.EnemyName;
//             enemyNameStr = enemyPack.EnemyName;
//             healthSlider.maxValue = enemyPack.MaxHealth;
//             maxHealth = enemyPack.MaxHealth;
//             healthSlider.value = enemyPack.CurrentHealth;
//             currentHealth = enemyPack.CurrentHealth;
//             armorSlider.maxValue = enemyPack.MaxArmor;
//             maxArmor = enemyPack.MaxArmor;
//             armorSlider.value = enemyPack.CurrentArmor;
//             currentArmor = enemyPack.CurrentArmor;
//         }
//         catch
//         {
          
//         }
        
//     }
// }
