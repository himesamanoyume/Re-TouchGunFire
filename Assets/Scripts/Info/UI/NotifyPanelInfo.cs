using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
    public class NotifyPanelInfo : UIInfo
    {
        
        void Start()
        {
            Name = "NotifyPanelInfo";
            Init();
        }

        public Transform center;
        public Text notifyText;
        public Slider countdownLeft;
        public Slider countdownRight;

        
        private bool isCountdown;


        protected sealed override void Init()
        {
            base.Init();
            center = transform.Find("Point/Center");
            center.GetComponent<RectTransform>().offsetMax = offScreen;
            notifyText = center.Find("Container/Text").GetComponent<Text>();
            countdownLeft = center.Find("CountdownBarLeft").GetComponent<Slider>();
            countdownRight = center.Find("CountdownBarRight").GetComponent<Slider>();
        }

        public void ShowNotifyPanel(string text, float countdown){
            notifyText.text = text;
            countdownLeft.maxValue = countdown;
            countdownLeft.value = countdown;
            countdownRight.maxValue = countdown;
            countdownRight.value = countdown;
            center.GetComponent<RectTransform>().offsetMax = inTheScreen;

            isCountdown = true;
        }

        private void Update() {
            CountDownRunning(center, countdownLeft, countdownRight, isCountdown);
        }

        // void CountDownRunning(){
        //     if(!isCountdown) return;
        //     countdownLeft.value -= Time.deltaTime;
        //     countdownRight.value -= Time.deltaTime;
        //     if(countdownLeft.value <= 0 && countdownRight.value <= 0){
        //         isCountdown = false;
        //         center.GetComponent<RectTransform>().offsetMax = offScreen;
        //     }
        // }
    }
}

