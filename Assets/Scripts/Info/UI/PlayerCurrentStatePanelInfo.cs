// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using ReTouchGunFire.Mediators;
// using SocketProtocol;
// using Google.Protobuf.Collections;

// namespace ReTouchGunFire.PanelInfo{

//     public class PlayerCurrentStatePanelInfo : UIInfo
//     {
//         [SerializeField] Transform container;
//         // RectTransform containerRect;

//         [SerializeField] Slider armorBar;
//         [SerializeField] Slider hpBar;
//         [SerializeField] Text uidBarText;

//         private void Start() {
//             Name = "PlayerCurrentStatePanelInfo";
//             Init();
//         }

//         protected override void Init()
//         {
//             base.Init();
//             container = transform.Find("Point/BottomCenter/Container");
//             // containerRect = container.GetComponent<RectTransform>();

//             armorBar = container.Find("ArmorBar").GetComponent<Slider>();
//             hpBar = container.Find("HpBar").GetComponent<Slider>();
//             uidBarText = container.Find("UidBar/Text").GetComponent<Text>();
//             EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);
//             networkMediator.GetPlayerInfo.playerInfoUpdateCallback += UpdatePlayerInfoCallback;
//         }

//         void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
//         void PlayerInfoUpdate(){
//             // uidBarText.text = "UID:"+GameLoop.Instance.GetComponent<PlayerInfo>().uid.ToString();
//             uidBarText.text = "UID:"+networkMediator.playerSelfUid;
//         }

//         UpdatePlayerInfoPack _updatePlayerInfoPack = null;

//         private void Update() {
//             if (_updatePlayerInfoPack != null)
//             {
//                 armorBar.maxValue = _updatePlayerInfoPack.MaxArmor;
//                 // armorBar.value = _updatePlayerInfoPack.CurrentArmor;
//                 armorBar.value = Mathf.Lerp(armorBar.value, _updatePlayerInfoPack.CurrentArmor, 0.5f);
//                 hpBar.maxValue = _updatePlayerInfoPack.MaxHealth;
//                 // hpBar.value = _updatePlayerInfoPack.CurrentHealth;
//                 hpBar.value = Mathf.Lerp(hpBar.value, _updatePlayerInfoPack.CurrentHealth, 0.5f);
//             }
//         }

//         public void UpdatePlayerInfoCallback(UpdatePlayerInfoPack updatePlayerInfoPack){
//             _updatePlayerInfoPack = updatePlayerInfoPack;
//         }
//     }
// }

