using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;


namespace ReTouchGunFire.PanelInfo{

    public class ItemBarInfo : UIInfo
    {

        void Start()
        {
            Name = "ItemBarInfo";
            Init();
        }

        [SerializeField] Text titleNameText;
        [SerializeField] Text coinPriceText;
        [SerializeField] Text diamondPriceText;
        [SerializeField] float coinPrice;
        [SerializeField] float diamondPrice;


        protected sealed override void Init()
        {
            base.Init();
            titleNameText = transform.Find("Content/Text").GetComponent<Text>();
            coinPriceText = transform.Find("Content/CoinText").GetComponent<Text>();
            diamondPriceText = transform.Find("Content/DiamondText").GetComponent<Text>();
            SetInfo();
        }

        public void InitInfo(ItemInfo itemInfo, bool isGun){
            this.itemInfo = itemInfo;
            this.isGun = isGun;
        }

        [SerializeField] ItemInfo itemInfo;
        [SerializeField] bool isGun;

        void SetInfo(){
            if (isGun)
            {
                titleNameText.text = ((GunInfo)itemInfo).GunName;
            }else
            {
                titleNameText.text = ((EquipmentInfo)itemInfo).EquipmentName;
            }
            coinPrice = itemInfo.Price;
            diamondPrice = itemInfo.DiamondPrice;
            coinPriceText.text = coinPrice.ToString();
            diamondPriceText.text = diamondPrice.ToString("f2");
            if (!itemInfo.Block)
            {
                coinPriceText.text = "已解锁";
                diamondPriceText.gameObject.SetActive(false);
            }
        }
    }
    
}


