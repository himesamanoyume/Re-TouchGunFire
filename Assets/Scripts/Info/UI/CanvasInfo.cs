// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// namespace ReTouchGunFire.PanelInfo{
//     public sealed class CanvasInfo : UIInfo
//     {
//         public Transform level1;
//         public Transform level2;
//         public Transform level3;
//         public Transform level4;
//         public Transform level5;
//         public Transform level6;
//         public Transform levelBackButton;
//         public Transform levelTwiceConfirm;
//         public Transform levelLoading;
//         public Camera mainCamera;

//         private void Start() {
//             Name = "CanvasInfo";
//             Init();
//         }

//         protected sealed override void Init(){
//             base.Init();
//             level1 = transform.GetChild(0);
//             level2 = transform.GetChild(1);
//             level3 = transform.GetChild(2);
//             level4 = transform.GetChild(3);
//             level5 = transform.GetChild(4);
//             level6 = transform.GetChild(5);
//             levelBackButton = transform.GetChild(6);
//             levelTwiceConfirm = transform.GetChild(7);
//             levelLoading = transform.GetChild(8);
//             mainCamera = Camera.main;
//             DontDestroyOnLoad(this);
//             DontDestroyOnLoad(mainCamera);
//             transform.GetComponent<Canvas>().worldCamera = mainCamera;
//         }

//         public Transform Canvas{
//             get{ return this.transform;}
//         }
        
//     }
// }

