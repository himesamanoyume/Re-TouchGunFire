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
        public InputField registerPartPlayerName;
        public InputField registerPartAccount;
        public InputField registerPartPassword;
        public Button registerPartBackButton;
        public Button loginPartLoginButton;
        public Button loginPartRegisterButton;
        public Button loginPartCancelButton;
        public Button registerSendRegisterButton;


        public LoginRequest loginRequest;
        public RegisterRequest registerRequest;

        private void Start() {
            Name = "LoginRegisterPanelInfo";
            Init();
        }

        // bool isLogin = true;
        
        protected sealed override void Init()
        {
            base.Init();

            loginRequest = (LoginRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.Login);

            registerRequest = (RegisterRequest)requestMediator.GetRequest(SocketProtocol.ActionCode.Register);

            loginPart = transform.Find("Point/Center/LoginPart");
            registerPart = transform.Find("Point/Center/RegisterPart");
            loginPartAccount = loginPart.Find("Container/AccountInputField").GetComponent<InputField>();
            loginPartPassword = loginPart.Find("Container/PasswordInputField").GetComponent<InputField>();
            registerPartPlayerName = registerPart.Find("Container/PlayerNameInputField").GetComponent<InputField>();
            registerPartAccount = registerPart.Find("Container/AccountInputField").GetComponent<InputField>();
            registerPartPassword = registerPart.Find("Container/PasswordInputField").GetComponent<InputField>();
            registerPartBackButton = registerPart.transform.Find("TitleContent/BackButton").GetComponent<Button>();
            loginPartLoginButton = loginPart.Find("Container/LoginButton").GetComponent<Button>();
            loginPartCancelButton = loginPart.Find("Container/CancelButton").GetComponent<Button>();
            loginPartRegisterButton = loginPart.Find("Container/RegisterButton").GetComponent<Button>();
            registerSendRegisterButton = registerPart.Find("Container/SendRegisterButton").GetComponent<Button>();

            loginPartLoginButton.onClick.AddListener(()=>{
                
                if(loginPartAccount.text.Equals("") && loginPartPassword.text.Equals("")){
                    panelMediator.ShowNotifyPanel("未输入账号密码",2f);
                    return;
                }
                if (loginPartAccount.text.Equals(""))
                {
                    panelMediator.ShowNotifyPanel("账号不能为空",2f);
                    return;
                }
                if (loginPartPassword.text.Equals(""))
                {
                    panelMediator.ShowNotifyPanel("密码不能为空",2f);
                    return;
                }
                loginRequest.SendRequest(loginPartAccount.text, loginPartPassword.text);
            });

            loginPartCancelButton.onClick.AddListener(()=>{
                panelMediator.PopPanel(true);
            });

            registerSendRegisterButton.onClick.AddListener(()=>{

                if(registerPartPlayerName.text.Equals("") && registerPartAccount.text.Equals("") && registerPartPassword.text.Equals("")){
                    panelMediator.ShowNotifyPanel("必要信息未填入",2f);
                    return;
                }
                if (registerPartPlayerName.text.Equals(""))
                {
                    panelMediator.ShowNotifyPanel("玩家名不能为空",2f);
                    return;
                }
                if (registerPartAccount.text.Equals(""))
                {
                    panelMediator.ShowNotifyPanel("账号不能为空",2f);
                    return;
                }
                if (registerPartPassword.text.Equals(""))
                {
                    panelMediator.ShowNotifyPanel("密码不能为空",2f);
                    return;
                }
                registerRequest.SendRequest(registerPartPlayerName.text, registerPartAccount.text, registerPartPassword.text);

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

    }
}


