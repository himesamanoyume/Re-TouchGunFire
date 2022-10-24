using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ReTouchGunFire.PanelInfo{

    public class PlayerPropsPanelInfo : UIInfo
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
        [Tooltip("主武器1名字")]
        public Text m1wGunName;
        [Tooltip("主武器1类型")]
        public Text m1wGunType;
        [Tooltip("主武器1基础伤害")]
        public Text m1wBaseDmg;
        [Tooltip("主武器1总暴击率")]
        public Text m1wTotalCDmgRate;
        [Tooltip("主武器1总暴击伤害")]
        public Text m1wTotalCDmg;
        [Tooltip("主武器1总爆头伤害")]
        public Text m1wTotalHeadshotDmg;
        [Tooltip("主武器1总穿透率")]
        public Text m1wTotalPRate;
        [Tooltip("主武器1总破甲效率")]
        public Text m1wTotalAbe;
        [Tooltip("主武器2名字")]
        public Text m2wGunName;
        [Tooltip("主武器2类型")]
        public Text m2wGunType;
        [Tooltip("主武器2基础伤害")]
        public Text m2wBaseDmg;
        [Tooltip("主武器2总暴击率")]
        public Text m2wTotalCDmgRate;
        [Tooltip("主武器2总暴击伤害")]
        public Text m2wTotalCDmg;
        [Tooltip("主武器2总爆头伤害")]
        public Text m2wTotalHeadshotDmg;
        [Tooltip("主武器2总穿透率")]
        public Text m2wTotalPRate;
        [Tooltip("主武器2总破甲效率")]
        public Text m2wTotalAbe;
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
        private Transform m1wBar;
        private Transform m2wBar;
        private Transform handgunBar;

        void Start()
        {
            Name = "PlayerPropsPanelInfo";
            Init();
        }

        public override void Init()
        {
            base.Init();
            content = transform.Find("Point/LeftBottom/Container/Scroll View/Viewport/Content");
            propsBar = content.Find("PropsBar");
            m1wBar = content.Find("Main1WeaponBar");
            m2wBar = content.Find("Main2WeaponBar");
            handgunBar = content.Find("HandGunBar");
            InitPropsBar();
            InitM1wBar();
            InitM2wBar();
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

        void InitM1wBar(){
            m1wGunName = m1wBar.Find("GunName/Value").GetComponent<Text>();
            m1wGunType = m1wBar.Find("GunType/Value").GetComponent<Text>();
            m1wBaseDmg = m1wBar.Find("BaseDMG/Value").GetComponent<Text>();
            m1wTotalCDmgRate = m1wBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            m1wTotalCDmg = m1wBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            m1wTotalHeadshotDmg = m1wBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            m1wTotalPRate = m1wBar.Find("TotalPRate/Value").GetComponent<Text>();
            m1wTotalAbe = m1wBar.Find("TotalABE/Value").GetComponent<Text>();
        }

        void InitM2wBar(){
            m2wGunName = m2wBar.Find("GunName/Value").GetComponent<Text>();
            m2wGunType = m2wBar.Find("GunType/Value").GetComponent<Text>();
            m2wBaseDmg = m2wBar.Find("BaseDMG/Value").GetComponent<Text>();
            m2wTotalCDmgRate = m2wBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            m2wTotalCDmg = m2wBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            m2wTotalHeadshotDmg = m2wBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            m2wTotalPRate = m2wBar.Find("TotalPRate/Value").GetComponent<Text>();
            m2wTotalAbe = m2wBar.Find("TotalABE/Value").GetComponent<Text>();
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

