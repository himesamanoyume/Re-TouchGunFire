// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using ReTouchGunFire.Mediators;
// using SocketProtocol;
// using Google.Protobuf.Collections;


// namespace ReTouchGunFire.PanelInfo{

//     public sealed class PlayerPropsPanelInfo : UIInfo
//     {
//         [Tooltip("生命值")]
//         [SerializeField] Text health;
//         [Tooltip("护甲值")]
//         [SerializeField] Text armor;
//         [Tooltip("基础伤害加成")]
//         [SerializeField] Text baseDmgBonus;
//         [Tooltip("暴击率加成")]
//         [SerializeField] Text cDmgRateBonus;
//         [Tooltip("暴击伤害加成")]
//         [SerializeField] Text cDmgBonus;
//         [Tooltip("爆头伤害加成")]
//         [SerializeField] Text headshotDmgBonus;
//         [Tooltip("穿透率加成")]
//         [SerializeField] Text pRateBonus;
//         [Tooltip("破甲效率加成")]
//         [SerializeField] Text abeBonus;
//         [Tooltip("自动步枪伤害加成")]
//         [SerializeField] Text arDmgBonus;
//         [Tooltip("精确射手步枪伤害加成")]
//         [SerializeField] Text dmrDmgBonus;
//         [Tooltip("微型冲锋枪伤害加成")]
//         [SerializeField] Text smgDmgBonus;
//         [Tooltip("霰弹枪伤害加成")]
//         [SerializeField] Text sgDmgBonus;
//         [Tooltip("狙击步枪伤害加成")]
//         [SerializeField] Text srDmgBonus;
//         [Tooltip("轻机枪伤害加成")]
//         [SerializeField] Text mgDmgBonus;
//         [Tooltip("手枪伤害加成")]
//         [SerializeField] Text hgDmgBonus;
//         [Tooltip("主武器名字")]
//         [SerializeField] Text mainGunName;
//         [Tooltip("主武器类型")]
//         [SerializeField] Text mainGunType;
//         [Tooltip("主武器基础伤害")]
//         [SerializeField] Text mainBaseDmg;
//         [Tooltip("主武器总暴击率")]
//         [SerializeField] Text mainTotalCDmgRate;
//         [Tooltip("主武器总暴击伤害")]
//         [SerializeField] Text mainTotalCDmg;
//         [Tooltip("主武器总爆头伤害")]
//         [SerializeField] Text mainTotalHeadshotDmg;
//         [Tooltip("主武器总穿透率")]
//         [SerializeField] Text mainTotalPRate;
//         [Tooltip("主武器总破甲效率")]
//         [SerializeField] Text mainTotalAbe;
//         [Tooltip("副武器名字")]
//         [SerializeField] Text handgunGunName;
//         [Tooltip("副武器类型")]
//         [SerializeField] Text handgunGunType;
//         [Tooltip("副武器基础伤害")]
//         [SerializeField] Text handgunBaseDmg;
//         [Tooltip("副武器总暴击率")]
//         [SerializeField] Text handgunTotalCDmgRate;
//         [Tooltip("副武器总暴击伤害")]
//         [SerializeField] Text handgunTotalCDmg;
//         [Tooltip("副武器总爆头伤害")]
//         [SerializeField] Text handgunTotalHeadshotDmg;
//         [Tooltip("副武器总穿透率")]
//         [SerializeField] Text handgunTotalPRate;
//         [Tooltip("副武器总破甲效率")]
//         [SerializeField] Text handgunTotalAbe;
        
//         [SerializeField] Transform point;
//         private Transform content;
//         private Transform propsBar;
//         private Transform mainGunBar;
//         private Transform handgunBar;

//         void Start()
//         {
//             Name = "PlayerPropsPanelInfo";
//             Init();
//         }

//         protected sealed override void Init()
//         {
//             base.Init();

//             point = transform.Find("Point");
//             content = transform.Find("Point/LeftBottom/Container/Scroll View/Viewport/Content");
//             propsBar = content.Find("PropsBar");
//             mainGunBar = content.Find("MainGunBar");
//             handgunBar = content.Find("HandGunBar");
//             point.GetComponent<RectTransform>().offsetMax = offScreen;
//             InitPropsBar();
//             InitMainGunBar();
//             InitHandGunBar();
//             EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
//             EventMgr.AddListener<BackpackPanelOpenNotify>(OnBackpackOpen);
//             EventMgr.AddListener<BackpackPanelCloseNotify>(OnBackpackClose);
//             networkMediator.GetPlayerInfo.playerInfoUpdateCallback += UpdatePlayerInfoCallback;
//         }

//         void InitPropsBar(){
//             health = propsBar.Find("HP/Value").GetComponent<Text>();
//             armor = propsBar.Find("Armor/Value").GetComponent<Text>();
//             baseDmgBonus = propsBar.Find("BaseDMGBonus/Value").GetComponent<Text>();
//             cDmgRateBonus = propsBar.Find("CRITDMGRateBonus/Value").GetComponent<Text>();
//             cDmgBonus = propsBar.Find("CRITDMGBonus/Value").GetComponent<Text>();
//             headshotDmgBonus = propsBar.Find("HeadshotDMGBonus/Value").GetComponent<Text>();
//             pRateBonus = propsBar.Find("PRateBonus/Value").GetComponent<Text>();
//             abeBonus = propsBar.Find("ABE_Bonus/Value").GetComponent<Text>();
//             arDmgBonus = propsBar.Find("AR_DMGBonus/Value").GetComponent<Text>();
//             dmrDmgBonus = propsBar.Find("DMR_DMGBonus/Value").GetComponent<Text>();
//             smgDmgBonus = propsBar.Find("SMG_DMGBonus/Value").GetComponent<Text>();
//             sgDmgBonus = propsBar.Find("SG_DMGBonus/Value").GetComponent<Text>();
//             srDmgBonus = propsBar.Find("SR_DMGBonus/Value").GetComponent<Text>();
//             mgDmgBonus = propsBar.Find("MG_DMGBonus/Value").GetComponent<Text>();
//             hgDmgBonus = propsBar.Find("HG_DMGBonus/Value").GetComponent<Text>();
//         }

//         void InitMainGunBar(){
//             mainGunName = mainGunBar.Find("GunName/Value").GetComponent<Text>();
//             mainGunType = mainGunBar.Find("GunType/Value").GetComponent<Text>();
//             mainBaseDmg = mainGunBar.Find("BaseDMG/Value").GetComponent<Text>();
//             mainTotalCDmgRate = mainGunBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
//             mainTotalCDmg = mainGunBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
//             mainTotalHeadshotDmg = mainGunBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
//             mainTotalPRate = mainGunBar.Find("TotalPRate/Value").GetComponent<Text>();
//             mainTotalAbe = mainGunBar.Find("TotalABE/Value").GetComponent<Text>();
//         }

//         void InitHandGunBar(){
//             handgunGunName = handgunBar.Find("GunName/Value").GetComponent<Text>();
//             handgunGunType = handgunBar.Find("GunType/Value").GetComponent<Text>();
//             handgunBaseDmg = handgunBar.Find("BaseDMG/Value").GetComponent<Text>();
//             handgunTotalCDmgRate = handgunBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
//             handgunTotalCDmg = handgunBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
//             handgunTotalHeadshotDmg = handgunBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
//             handgunTotalPRate = handgunBar.Find("TotalPRate/Value").GetComponent<Text>();
//             handgunTotalAbe = handgunBar.Find("TotalABE/Value").GetComponent<Text>();
//         }

//         void OnBackpackOpen(BackpackPanelOpenNotify evt) => BackpackOpen();
//         void BackpackOpen(){
//             point.GetComponent<RectTransform>().offsetMax = inTheScreen;
//         }

//         void OnBackpackClose(BackpackPanelCloseNotify evt) => BackpackClose();
//         void BackpackClose(){
//             point.GetComponent<RectTransform>().offsetMax = offScreen;
//         }

//         void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
//         void RestorePanel(){
//             point.GetComponent<RectTransform>().offsetMax = offScreen;
//             panelMediator.MovePanelLevel(EUIPanelType.PlayerPropsPanel, EUILevel.Level4);
//         }

//         public void UpdatePlayerInfoCallback(UpdatePlayerInfoPack updatePlayerInfoPack){
            
//             health.text = updatePlayerInfoPack.MaxHealth.ToString("f0");
//             armor.text = updatePlayerInfoPack.MaxArmor.ToString("f0");
//             baseDmgBonus.text = (updatePlayerInfoPack.BaseDmgRateBonus * 100).ToString("f1") + "%";
//             cDmgRateBonus.text = (updatePlayerInfoPack.CritDmgRateBonus * 100).ToString("f1") + "%";
//             cDmgBonus.text = (updatePlayerInfoPack.CritDmgBonus * 100).ToString("f1") + "%";
//             headshotDmgBonus.text = (updatePlayerInfoPack.HeadshotDmgBonus * 100).ToString("f1") + "%";
//             pRateBonus.text = (updatePlayerInfoPack.PRateBonus * 100).ToString("f1") + "%";
//             abeBonus.text = (updatePlayerInfoPack.AbeBonus * 100).ToString("f1") + "%";
//             arDmgBonus.text = (updatePlayerInfoPack.ArDmgBonus * 100).ToString("f1") + "%";
//             dmrDmgBonus.text = (updatePlayerInfoPack.DmrDmgBonus * 100).ToString("f1") + "%";
//             smgDmgBonus.text = (updatePlayerInfoPack.SmgDmgBonus * 100).ToString("f1") + "%";
//             sgDmgBonus.text = (updatePlayerInfoPack.SgDmgBonus * 100).ToString("f1") + "%";
//             srDmgBonus.text = (updatePlayerInfoPack.SrDmgBonus * 100).ToString("f1") + "%";
//             mgDmgBonus.text = (updatePlayerInfoPack.MgDmgBonus * 100).ToString("f1") + "%";
//             hgDmgBonus.text = (updatePlayerInfoPack.HgDmgBonus * 100).ToString("f1") + "%";
//         }
//     }
// }

