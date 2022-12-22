// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using ReTouchGunFire.Mediators;
// using SocketProtocol;


// namespace ReTouchGunFire.PanelInfo{

//     public class ItemBarInfo : UIInfo
//     {

//         void Start()
//         {
//             Name = "ItemBarInfo";
//             Init();
//         }

//         [SerializeField] Image contentImage;
//         [SerializeField] Text titleNameText;
//         [SerializeField] Text coinPriceText;
//         [SerializeField] Text diamondPriceText;
//         [SerializeField] float coinPrice;
//         [SerializeField] float diamondPrice;

//         Color greyBlackColor = new Color(0.15f,0.15f,0.15f);
//         Color useOrangeColor = new Color(0.4f,0.2f,0.05f);

//         protected sealed override void Init()
//         {
//             base.Init();
//             contentImage = transform.Find("Content").GetComponent<Image>();
//             titleNameText = transform.Find("Content/Text").GetComponent<Text>();
//             coinPriceText = transform.Find("Content/CoinText").GetComponent<Text>();
//             diamondPriceText = transform.Find("Content/DiamondText").GetComponent<Text>();
//             SetInfo();
//         }

//         public void InitInfo(ItemInfo itemInfo, bool isGun){
//             this.itemInfo = itemInfo;
//             this.isGun = isGun;
//         }

//         [SerializeField] ItemInfo itemInfo;
//         [SerializeField] bool isGun;
//         [SerializeField] bool use;

//         void SetInfo(){
//             if (isGun)
//             {
//                 titleNameText.text = ((GunInfo)itemInfo).GunName;
//             }else
//             {
//                 titleNameText.text = ((EquipmentInfo)itemInfo).EquipmentName;
//             }
//             coinPrice = itemInfo.Price;
//             diamondPrice = itemInfo.DiamondPrice;
//             coinPriceText.text = coinPrice.ToString();
//             diamondPriceText.text = diamondPrice.ToString("f2");
//             use = itemInfo.Use;
//             if (use)
//             {
//                 contentImage.color = useOrangeColor;
//             }else
//             {
//                 contentImage.color = greyBlackColor;
//             }
//             if (!itemInfo.Block)
//             {
//                 coinPriceText.text = "已解锁";
//                 diamondPriceText.gameObject.SetActive(false);
//             }
//         }
//     }
    
// }


