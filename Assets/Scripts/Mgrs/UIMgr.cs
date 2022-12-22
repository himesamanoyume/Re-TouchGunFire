// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using ReTouchGunFire.Mediators;

// namespace ReTouchGunFire.Mgrs{
//     public sealed class UIMgr : IManager
//     {
//         public CanvasMediator canvasMediator;
//         private List<GameObject> panelList = new List<GameObject>();
//         public Dictionary<EUIPanelType, GameObject> panelDict = new Dictionary<EUIPanelType, GameObject>();
//         public UIMgr(){
//             Name = "UIMgr";
//         }

//         public override void Init(){
//             canvasMediator = GameLoop.Instance.GetMediator<CanvasMediator>();
//         }

//         public void InsertPanel(GameObject panel){
//             panelList.Insert(0, panel);
//         }

//         /// <summary>
//         /// 如果PanelList内没有面板了则返回true
//         /// </summary>
//         /// <returns></returns>
//         public bool CheckPanelList(){
//             if(panelList.Count > 0){
//                 return false;
//             }else{
//                 return true;
//             }
//         }

//         public void PopPanel(bool isDestroy){
//             if(isDestroy){
//                 GameObject.Destroy(panelList[0]);
//             }else{
//                 panelList[0].transform.GetChild(0).gameObject.SetActive(false);
//             }
            
//             if(panelList.Count!=0)
//                 panelList.Remove(panelList[0]);
//         }

//         public void MovePanelLevel(EUIPanelType uIPanelType, EUILevel uILevel){
//             if(panelDict.TryGetValue(uIPanelType,out GameObject panel)){
//                 panel.GetComponent<UIInfo>().currentLevel = uILevel;
//                 panel.transform.SetParent(canvasMediator.GetCanvasLevel(uILevel));
//             }else{
//                 // Debug.LogError(uIPanelType+" Panel spawned not yet.");
//             }
//         }
//     }
// }

