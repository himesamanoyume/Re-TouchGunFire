using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class LoginRegisterPanelInfo : UIInfo
    {

        public Transform loginPart;
        public Transform registerPart;
        public InputField loginPartAccount;
        public InputField loginPartPassword;
        public InputField registerPartAccount;
        public InputField registerPartPassword;
        public Button registerPartBackButton;
        public Button loginPartLoginButton;
        public Button loginPartRegisterButton;
        public Button loginPartCancelButton;
        public Button registerSendRegisterButton;


        public LoginRequest loginRequest;
        public RegisterRequest registerRequest;

        public PanelMediator panelMediator;
        private void Start() {
            Name = "LoginRegisterPanelInfo";
            Init();
        }

        // bool isLogin = true;
        
        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            loginRequest = gameObject.AddComponent<LoginRequest>();
            registerRequest = gameObject.AddComponent<RegisterRequest>();

            loginPart = transform.Find("Point/Center/LoginPart");
            registerPart = transform.Find("Point/Center/RegisterPart");
            loginPartAccount = loginPart.Find("Container/AccountInputField").GetComponent<InputField>();
            loginPartPassword = loginPart.Find("Container/PasswordInputField").GetComponent<InputField>();
            registerPartAccount = registerPart.Find("Container/AccountInputField").GetComponent<InputField>();
            registerPartPassword = registerPart.Find("Container/PasswordInputField").GetComponent<InputField>();
            registerPartBackButton = registerPart.transform.Find("TitleContent/BackButton").GetComponent<Button>();
            loginPartLoginButton = loginPart.Find("Container/LoginButton").GetComponent<Button>();
            loginPartCancelButton = loginPart.Find("Container/CancelButton").GetComponent<Button>();
            loginPartRegisterButton = loginPart.Find("Container/RegisterButton").GetComponent<Button>();
            registerSendRegisterButton = registerPart.Find("Container/SendRegisterButton").GetComponent<Button>();

            loginPartLoginButton.onClick.AddListener(()=>{
                
                // if(loginPartAccount.text != null && loginPartPassword.text != null)
                //     loginRequest.SendRequest(loginPartAccount.text, loginPartPassword.text);

                //temp
                loginRequest.SendRequest("123","123");
                //end
            });

            loginPartCancelButton.onClick.AddListener(()=>{
                panelMediator.PopPanel(true);
            });

            registerSendRegisterButton.onClick.AddListener(()=>{
                // if(registerPartAccount.text != null && registerPartPassword.text != null)
                //     registerRequest.SendRequest(registerPartAccount.text, loginPartPassword.text);
                registerRequest.SendRequest("123","123");
            });

            registerPartBackButton.onClick.AddListener(()=>{
                loginPart.GetComponent<RectTransform>().offsetMax = inTheScreen;
                registerPart.GetComponent<RectTransform>().offsetMax = offScreen;
            });

            loginPartRegisterButton.onClick.AddListener(()=>{
                loginPart.GetComponent<RectTransform>().offsetMax = offScreen;
                registerPart.GetComponent<RectTransform>().offsetMax = inTheScreen;
            });
        }

        // void ShowRegisterPart(){
        //     if(isLogin){
        //         loginPart.GetComponent<RectTransform>().offsetMax = inTheScreen;
        //         registerPart.GetComponent<RectTransform>().offsetMax = offScreen;
        //     }else{
        //         loginPart.GetComponent<RectTransform>().offsetMax = offScreen;
        //         registerPart.GetComponent<RectTransform>().offsetMax = inTheScreen;
        //     }
        //     isLogin = !isLogin;
        // }

        
    }
}


