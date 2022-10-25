using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ReTouchGunFire.PanelInfo{

    public sealed class PlayerPropsPanelInfo : UIInfo
    {
        [Tooltip("生命值")]
        public Text health;
        [Tooltip("护甲值")]
        public Text armor;
        [Tooltip("基础伤害加成")]
        public Text baseDmgBonus;
        [Tooltip("暴击率加成")]
        public Text cDmgRateBonus;
        [Tooltip("暴击伤害加成")]
        public Text cDmgBonus;
        [Tooltip("爆头伤害加成")]
        public Text headshotDmgBonus;
        [Tooltip("穿透率加成")]
        public Text pRateBonus;
        [Tooltip("破甲效率加成")]
        public Text abeBonus;
        [Tooltip("自动步枪伤害加成")]
        public Text arDmgBonus;
        [Tooltip("精确射手步枪伤害加成")]
        public Text dmrDmgBonus;
        [Tooltip("微型冲锋枪伤害加成")]
        public Text smgDmgBonus;
        [Tooltip("霰弹枪伤害加成")]
        public Text sgDmgBonus;
        [Tooltip("狙击步枪伤害加成")]
        public Text srDmgBonus;
        [Tooltip("轻机枪伤害加成")]
        public Text mgDmgBonus;
        [Tooltip("手枪伤害加成")]
        public Text hgDmgBonus;
        [Tooltip("主武器名字")]
        public Text mainGunName;
        [Tooltip("主武器类型")]
        public Text mainGunType;
        [Tooltip("主武器基础伤害")]
        public Text mainBaseDmg;
        [Tooltip("主武器总暴击率")]
        public Text mainTotalCDmgRate;
        [Tooltip("主武器总暴击伤害")]
        public Text mainTotalCDmg;
        [Tooltip("主武器总爆头伤害")]
        public Text mainTotalHeadshotDmg;
        [Tooltip("主武器总穿透率")]
        public Text mainTotalPRate;
        [Tooltip("主武器总破甲效率")]
        public Text mainTotalAbe;
        [Tooltip("副武器名字")]
        public Text handgunGunName;
        [Tooltip("副武器类型")]
        public Text handgunGunType;
        [Tooltip("副武器基础伤害")]
        public Text handgunBaseDmg;
        [Tooltip("副武器总暴击率")]
        public Text handgunTotalCDmgRate;
        [Tooltip("副武器总暴击伤害")]
        public Text handgunTotalCDmg;
        [Tooltip("副武器总爆头伤害")]
        public Text handgunTotalHeadshotDmg;
        [Tooltip("副武器总穿透率")]
        public Text handgunTotalPRate;
        [Tooltip("副武器总破甲效率")]
        public Text handgunTotalAbe;
        
        private Transform content;
        private Transform propsBar;
        private Transform mainGunBar;
        private Transform handgunBar;

        void Start()
        {
            Name = "PlayerPropsPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            content = transform.Find("Point/LeftBottom/Container/Scroll View/Viewport/Content");
            propsBar = content.Find("PropsBar");
            mainGunBar = content.Find("MainGunBar");
            handgunBar = content.Find("HandGunBar");
            InitPropsBar();
            InitMainGunBar();
            InitHandGunBar();
        }

        void InitPropsBar(){
            health = propsBar.Find("HP/Value").GetComponent<Text>();
            armor = propsBar.Find("Armor/Value").GetComponent<Text>();
            baseDmgBonus = propsBar.Find("BaseDMGBonus/Value").GetComponent<Text>();
            cDmgRateBonus = propsBar.Find("CRITDMGRateBonus/Value").GetComponent<Text>();
            cDmgBonus = propsBar.Find("CRITDMGBonus/Value").GetComponent<Text>();
            headshotDmgBonus = propsBar.Find("HeadshotDMGBonus/Value").GetComponent<Text>();
            pRateBonus = propsBar.Find("PRateBonus/Value").GetComponent<Text>();
            abeBonus = propsBar.Find("ABE_Bonus/Value").GetComponent<Text>();
            arDmgBonus = propsBar.Find("AR_DMGBonus/Value").GetComponent<Text>();
            dmrDmgBonus = propsBar.Find("DMR_DMGBonus/Value").GetComponent<Text>();
            smgDmgBonus = propsBar.Find("SMG_DMGBonus/Value").GetComponent<Text>();
            sgDmgBonus = propsBar.Find("SG_DMGBonus/Value").GetComponent<Text>();
            srDmgBonus = propsBar.Find("SR_DMGBonus/Value").GetComponent<Text>();
            mgDmgBonus = propsBar.Find("MG_DMGBonus/Value").GetComponent<Text>();
            hgDmgBonus = propsBar.Find("HG_DMGBonus/Value").GetComponent<Text>();
        }

        void InitMainGunBar(){
            mainGunName = mainGunBar.Find("GunName/Value").GetComponent<Text>();
            mainGunType = mainGunBar.Find("GunType/Value").GetComponent<Text>();
            mainBaseDmg = mainGunBar.Find("BaseDMG/Value").GetComponent<Text>();
            mainTotalCDmgRate = mainGunBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            mainTotalCDmg = mainGunBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            mainTotalHeadshotDmg = mainGunBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            mainTotalPRate = mainGunBar.Find("TotalPRate/Value").GetComponent<Text>();
            mainTotalAbe = mainGunBar.Find("TotalABE/Value").GetComponent<Text>();
        }

        void InitHandGunBar(){
            handgunGunName = handgunBar.Find("GunName/Value").GetComponent<Text>();
            handgunGunType = handgunBar.Find("GunType/Value").GetComponent<Text>();
            handgunBaseDmg = handgunBar.Find("BaseDMG/Value").GetComponent<Text>();
            handgunTotalCDmgRate = handgunBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            handgunTotalCDmg = handgunBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            handgunTotalHeadshotDmg = handgunBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            handgunTotalPRate = handgunBar.Find("TotalPRate/Value").GetComponent<Text>();
            handgunTotalAbe = handgunBar.Find("TotalABE/Value").GetComponent<Text>();
        }
    }
}

