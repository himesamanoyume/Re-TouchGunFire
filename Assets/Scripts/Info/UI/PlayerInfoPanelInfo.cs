// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using ReTouchGunFire.Mediators;
// using SocketProtocol;

// namespace ReTouchGunFire.PanelInfo{

//     public sealed class PlayerInfoPanelInfo : UIInfo
//     {
//         [SerializeField] Slider expBar;
//         [SerializeField] Text playerNameText;
//         [SerializeField] Text playerLevelText;

//         private Transform content;
//         // PlayerInfo playerInfo;

//         void Start()
//         {
//             Name = "PlayerInfoPanelInfo";
//             Init();
//         }

//         protected sealed override void Init(){
//             base.Init();

//             // playerInfo = GameLoop.Instance.GetComponent<PlayerInfo>();
//             content = transform.Find("Point/LeftBottom/Container/Player/Content");
//             expBar = content.Find("ExpItem/ExpBar").GetComponent<Slider>();
//             playerNameText = content.Find("PlayerInfo/PlayerNameText").GetComponent<Text>();
//             playerLevelText = content.Find("PlayerInfo/PlayerLevelText").GetComponent<Text>();
//             // EventMgr.AddListener<PlayerInfoUpdateNotify>(OnPlayerInfoUpdate);
//             networkMediator.GetPlayerInfo.playerInfoUpdateCallback += UpdatePlayerInfoCallback;
//             EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
//         }
        
//         void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
//         void RestorePanel(){
//             panelMediator.MovePanelLevel(EUIPanelType.PlayerInfoPanel, EUILevel.Level1);
//         }

//         // void OnPlayerInfoUpdate(PlayerInfoUpdateNotify evt) => PlayerInfoUpdate();
//         // void PlayerInfoUpdate(){
//         //     Loom.QueueOnMainThread(()=>{
//         //         playerNameText.text = playerInfo.playerName;
//         //         playerLevelText.text = playerInfo.level.ToString();
//         //         expBar.value = playerInfo.currentExp;
//         //     });
//         // }

//         public void UpdatePlayerInfoCallback(UpdatePlayerInfoPack updatePlayerInfoPack){
//             if (updatePlayerInfoPack.Uid == networkMediator.playerSelfUid)
//             {
//                 playerNameText.text = updatePlayerInfoPack.PlayerName;
//                 playerLevelText.text = updatePlayerInfoPack.Level.ToString();
//                 expBar.maxValue = updatePlayerInfoPack.MaxExp;
//                 expBar.value = updatePlayerInfoPack.CurrentExp;
//             }
//         }

//     }
// }


