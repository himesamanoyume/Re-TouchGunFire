using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class CanvasMediator : IMediator
    {
        public UIMgr m_uiMgr = null;
        public AbMediator m_abMediator = null;
        public GameObject m_canvas = null;
        
        public CanvasMediator(){
            Name = "CanvasMediator";  
        }

        public override void Init()
        {
            m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
        }

        public void InitCanvas(){

            if(GameLoop.Instance.TryGetComponent<AbMediator>(out AbMediator abMediator)){
                m_abMediator = abMediator;
            }else{
                Debug.LogWarning("未拿到对应组件");
            }   
            m_canvas = m_abMediator.SyncLoadABRes("prefabs", "Canvas", null);
            m_canvas.name = "Canvas";
            // Debug.Log(canvas.name);
            m_canvas.AddComponent<CanvasInfo>().InitCanvasChild();
        }

        public Transform GetCanvasLevel(EUILevel eUILevel){
            switch(eUILevel){
                case EUILevel.Level1:
                    return m_canvas.GetComponent<CanvasInfo>().Level1;
                case EUILevel.Level2:
                    return m_canvas.GetComponent<CanvasInfo>().Level2;
                case EUILevel.Level3:
                    return m_canvas.GetComponent<CanvasInfo>().Level3;
                case EUILevel.Level4:
                    return m_canvas.GetComponent<CanvasInfo>().Level4;
            }
            return null;
        }
    }
}
