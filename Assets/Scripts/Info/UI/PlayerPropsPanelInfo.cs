using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ReTouchGunFire.PanelInfo{

    public class PlayerPropsPanelInfo : UIInfo
    {
        [Tooltip("生命值")]
        public Text m_health;
        [Tooltip("护甲值")]
        public Text m_armor;
        [Tooltip("基础伤害加成")]
        public Text m_baseDmgBonus;
        [Tooltip("暴击率加成")]
        public Text m_cDmgRateBonus;
        [Tooltip("暴击伤害加成")]
        public Text m_cDmgBonus;
        [Tooltip("爆头伤害加成")]
        public Text m_headshotDmgBonus;
        [Tooltip("穿透率加成")]
        public Text m_pRateBonus;
        [Tooltip("破甲效率加成")]
        public Text m_abeBonus;
        [Tooltip("自动步枪伤害加成")]
        public Text m_arDmgBonus;
        [Tooltip("精确射手步枪伤害加成")]
        public Text m_dmrDmgBonus;
        [Tooltip("微型冲锋枪伤害加成")]
        public Text m_smgDmgBonus;
        [Tooltip("霰弹枪伤害加成")]
        public Text m_sgDmgBonus;
        [Tooltip("狙击步枪伤害加成")]
        public Text m_srDmgBonus;
        [Tooltip("轻机枪伤害加成")]
        public Text m_mgDmgBonus;
        [Tooltip("手枪伤害加成")]
        public Text m_hgDmgBonus;
        [Tooltip("主武器1名字")]
        public Text m_m1wGunName;
        [Tooltip("主武器1类型")]
        public Text m_m1wGunType;
        [Tooltip("主武器1基础伤害")]
        public Text m_m1wBaseDmg;
        [Tooltip("主武器1总暴击率")]
        public Text m_m1wTotalCDmgRate;
        [Tooltip("主武器1总暴击伤害")]
        public Text m_m1wTotalCDmg;
        [Tooltip("主武器1总爆头伤害")]
        public Text m_m1wTotalHeadshotDmg;
        [Tooltip("主武器1总穿透率")]
        public Text m_m1wTotalPRate;
        [Tooltip("主武器1总破甲效率")]
        public Text m_m1wTotalAbe;
        [Tooltip("主武器2名字")]
        public Text m_m2wGunName;
        [Tooltip("主武器2类型")]
        public Text m_m2wGunType;
        [Tooltip("主武器2基础伤害")]
        public Text m_m2wBaseDmg;
        [Tooltip("主武器2总暴击率")]
        public Text m_m2wTotalCDmgRate;
        [Tooltip("主武器2总暴击伤害")]
        public Text m_m2wTotalCDmg;
        [Tooltip("主武器2总爆头伤害")]
        public Text m_m2wTotalHeadshotDmg;
        [Tooltip("主武器2总穿透率")]
        public Text m_m2wTotalPRate;
        [Tooltip("主武器2总破甲效率")]
        public Text m_m2wTotalAbe;
        [Tooltip("副武器名字")]
        public Text m_handgunGunName;
        [Tooltip("副武器类型")]
        public Text m_handgunGunType;
        [Tooltip("副武器基础伤害")]
        public Text m_handgunBaseDmg;
        [Tooltip("副武器总暴击率")]
        public Text m_handgunTotalCDmgRate;
        [Tooltip("副武器总暴击伤害")]
        public Text m_handgunTotalCDmg;
        [Tooltip("副武器总爆头伤害")]
        public Text m_handgunTotalHeadshotDmg;
        [Tooltip("副武器总穿透率")]
        public Text m_handgunTotalPRate;
        [Tooltip("副武器总破甲效率")]
        public Text m_handgunTotalAbe;
        
        private Transform m_content;
        private Transform m_propsBar;
        private Transform m_m1wBar;
        private Transform m_m2wBar;
        private Transform m_handgunBar;

        void Start()
        {
            Name = "PlayerPropsPanelInfo";
            Init();
        }

        public override void Init()
        {
            base.Init();
            m_content = transform.Find("Point/LeftBottom/Container/Scroll View/Viewport/Content");
            m_propsBar = m_content.Find("PropsBar");
            m_m1wBar = m_content.Find("Main1WeaponBar");
            m_m2wBar = m_content.Find("Main2WeaponBar");
            m_handgunBar = m_content.Find("HandGunBar");
            InitPropsBar();
            InitM1wBar();
            InitM2wBar();
            InitHandGunBar();
        }

        void InitPropsBar(){
            m_health = m_propsBar.Find("HP/Value").GetComponent<Text>();
            m_armor = m_propsBar.Find("Armor/Value").GetComponent<Text>();
            m_baseDmgBonus = m_propsBar.Find("BaseDMGBonus/Value").GetComponent<Text>();
            m_cDmgRateBonus = m_propsBar.Find("CRITDMGRateBonus/Value").GetComponent<Text>();
            m_cDmgBonus = m_propsBar.Find("CRITDMGBonus/Value").GetComponent<Text>();
            m_headshotDmgBonus = m_propsBar.Find("HeadshotDMGBonus/Value").GetComponent<Text>();
            m_pRateBonus = m_propsBar.Find("PRateBonus/Value").GetComponent<Text>();
            m_abeBonus = m_propsBar.Find("ABE_Bonus/Value").GetComponent<Text>();
            m_arDmgBonus = m_propsBar.Find("AR_DMGBonus/Value").GetComponent<Text>();
            m_dmrDmgBonus = m_propsBar.Find("DMR_DMGBonus/Value").GetComponent<Text>();
            m_smgDmgBonus = m_propsBar.Find("SMG_DMGBonus/Value").GetComponent<Text>();
            m_sgDmgBonus = m_propsBar.Find("SG_DMGBonus/Value").GetComponent<Text>();
            m_srDmgBonus = m_propsBar.Find("SR_DMGBonus/Value").GetComponent<Text>();
            m_mgDmgBonus = m_propsBar.Find("MG_DMGBonus/Value").GetComponent<Text>();
            m_hgDmgBonus = m_propsBar.Find("HG_DMGBonus/Value").GetComponent<Text>();
        }

        void InitM1wBar(){
            m_m1wGunName = m_m1wBar.Find("GunName/Value").GetComponent<Text>();
            m_m1wGunType = m_m1wBar.Find("GunType/Value").GetComponent<Text>();
            m_m1wBaseDmg = m_m1wBar.Find("BaseDMG/Value").GetComponent<Text>();
            m_m1wTotalCDmgRate = m_m1wBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            m_m1wTotalCDmg = m_m1wBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            m_m1wTotalHeadshotDmg = m_m1wBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            m_m1wTotalPRate = m_m1wBar.Find("TotalPRate/Value").GetComponent<Text>();
            m_m1wTotalAbe = m_m1wBar.Find("TotalABE/Value").GetComponent<Text>();
        }

        void InitM2wBar(){
            m_m2wGunName = m_m2wBar.Find("GunName/Value").GetComponent<Text>();
            m_m2wGunType = m_m2wBar.Find("GunType/Value").GetComponent<Text>();
            m_m2wBaseDmg = m_m2wBar.Find("BaseDMG/Value").GetComponent<Text>();
            m_m2wTotalCDmgRate = m_m2wBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            m_m2wTotalCDmg = m_m2wBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            m_m2wTotalHeadshotDmg = m_m2wBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            m_m2wTotalPRate = m_m2wBar.Find("TotalPRate/Value").GetComponent<Text>();
            m_m2wTotalAbe = m_m2wBar.Find("TotalABE/Value").GetComponent<Text>();
        }

        void InitHandGunBar(){
            m_handgunGunName = m_handgunBar.Find("GunName/Value").GetComponent<Text>();
            m_handgunGunType = m_handgunBar.Find("GunType/Value").GetComponent<Text>();
            m_handgunBaseDmg = m_handgunBar.Find("BaseDMG/Value").GetComponent<Text>();
            m_handgunTotalCDmgRate = m_handgunBar.Find("TotalCRITDMGRate/Value").GetComponent<Text>();
            m_handgunTotalCDmg = m_handgunBar.Find("TotalCRITDMG/Value").GetComponent<Text>();
            m_handgunTotalHeadshotDmg = m_handgunBar.Find("TotalHeadshotDMG/Value").GetComponent<Text>();
            m_handgunTotalPRate = m_handgunBar.Find("TotalPRate/Value").GetComponent<Text>();
            m_handgunTotalAbe = m_handgunBar.Find("TotalABE/Value").GetComponent<Text>();
        }
    }
}

