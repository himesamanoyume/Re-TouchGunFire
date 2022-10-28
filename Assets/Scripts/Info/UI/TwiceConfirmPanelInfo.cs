using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public class TwiceConfirmPanelInfo : UIInfo
    {
        // public PanelMediator panelMediator;
        void Start()
        {
            Name = "TwiceConfirmPanelInfo";
            Init();
        }

        public Transform content;
        public Transform point;
        public Button confirmButton;
        public Button cancelButton;
        public Slider countdownLeft;
        public Slider countdownRight;
        public Text infoText;

        bool isCountdown;
        Action confirmDel;

        protected override void Init()
        {
            base.Init();
            point = transform.GetChild(0);
            content = transform.Find("Point/Center/Container/Content");
            confirmButton = content.Find("ConfirmButton").GetComponent<Button>();
            cancelButton = content.Find("CancelButton").GetComponent<Button>();
            countdownLeft = content.Find("CountdownBarLeft").GetComponent<Slider>();
            countdownRight = content.Find("CountdownBarRight").GetComponent<Slider>();
            infoText =  content.Find("InfoText").GetComponent<Text>();

            confirmButton.onClick.AddListener(()=>{
                confirmDel?.Invoke();
                confirmDel = null;
                isCountdown = false;
                point.gameObject.SetActive(false);
            });

            cancelButton.onClick.AddListener(()=>{
                confirmDel = null;
                isCountdown = false;
                point.gameObject.SetActive(false);
            });

            point.gameObject.SetActive(false);
        }

        private void Update() {
            CountDownRunning();
        }

        void CountDownRunning(){
            if(!isCountdown) return;
            countdownLeft.value -= Time.deltaTime;
            countdownRight.value -= Time.deltaTime;
            if(countdownLeft.value <= 0 && countdownRight.value <= 0){
                isCountdown = false;
                confirmDel = null;
                point.gameObject.SetActive(false);
            }
        }

        // void OnShowTwiceConfirmPanel(ShowTwiceConfirmPanelNotify evt) => ShowTwiceConfirmPanel();
        // void ShowTwiceConfirmPanel(){
        //     isCountdown = true;
        // }

        public void ShowTwiceConfirmPanel(string infoText, float countdown, Action confirmFunction){
            point.gameObject.SetActive(true);
            this.infoText.text = infoText;
            countdownLeft.maxValue = countdown;
            countdownLeft.value = countdown;
            countdownRight.maxValue = countdown;
            countdownRight.value = countdown;
            confirmDel = confirmFunction;

            isCountdown = true;
        }
    }
}

