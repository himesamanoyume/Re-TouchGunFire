using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;

namespace ReTouchGunFire.PanelInfo{
    public sealed class MainMenuPanelInfo : UIInfo
    {
        [SerializeField] AttackInviteRequest attackInviteRequest;
        [SerializeField] ReadyAttackRequest readyAttackRequest;
        [SerializeField] CancelReadyAttackRequest cancelReadyAttackRequest;
        [SerializeField] TeamMasterAttackNotifyRequest teamMasterAttackNotifyRequest;

        [SerializeField] Button attackCube;
        [SerializeField] Button backpackCube;
        [SerializeField] Button shopCube;
        [SerializeField] Button friendsCube;
        [SerializeField] Button buildingCube;
        [SerializeField] Button settingCube;

        [SerializeField] Button attackBackCube;
        [SerializeField] Button area1Cube;
        void Start()
        {
            Name = "MainMenuPanelInfo";
            Init();
        }

        private Transform mainTemplate;
        private Transform attackTemplate;

        protected sealed override void Init()
        {
            base.Init();
            
            mainTemplate = transform.Find("Point/RightBottom/Container/SelectMenuContent/MainTemplate");
            attackTemplate = transform.Find("Point/RightBottom/Container/SelectMenuContent/AttackTemplate");
            InitMainTemplate();
            InitAttackTemplate();

            attackInviteRequest = (AttackInviteRequest)requestMediator.GetRequest(ActionCode.AttackInvite);
            readyAttackRequest = (ReadyAttackRequest)requestMediator.GetRequest(ActionCode.ReadyAttack);
            cancelReadyAttackRequest = (CancelReadyAttackRequest)requestMediator.GetRequest(ActionCode.CancelReadyAttack);
            teamMasterAttackNotifyRequest = (TeamMasterAttackNotifyRequest)requestMediator.GetRequest(ActionCode.TeamMasterAttackNotify);
        }

        void InitMainTemplate(){
            attackCube = mainTemplate.Find("line1/AttackCube").GetComponent<Button>();
            backpackCube = mainTemplate.Find("line2/BackpackCube").GetComponent<Button>();
            shopCube = mainTemplate.Find("line2/ShopCube").GetComponent<Button>();
            friendsCube = mainTemplate.Find("line3/FriendsCube").GetComponent<Button>();
            buildingCube = mainTemplate.Find("line3/BuildingCube").GetComponent<Button>();
            settingCube = mainTemplate.Find("line4/SettingCube").GetComponent<Button>();

            GetFriendsRequest getFriendsRequest = (GetFriendsRequest)requestMediator.GetRequest(ActionCode.GetFriends);
            
            attackCube.onClick.AddListener(()=>{
                mainTemplate.localScale = Vector3.zero;
                attackTemplate.localScale = Vector3.one;
            });

            friendsCube.onClick.AddListener(()=>{
                if (panelMediator.GetPanel(EUIPanelType.FriendsPanel)!=null)
                {
                    getFriendsRequest.SendRequest();
                }
                panelMediator.PushPanel(EUIPanelType.FriendsPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<FriendsPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                });
            });

            shopCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.ShopPanel, 
                panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<ShopPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                    
                });
            });

            buildingCube.onClick.AddListener(()=>{
                panelMediator.ShowNotifyPanel("合成系统暂未开放~",3f);
            });
            
            backpackCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.BackpackPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<BackpackPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                    
                });
                panelMediator.MovePanelLevel(
                    EUIPanelType.PlayerPropsPanel, 
                    panelMediator.GetPanelLevelUp(panelMediator.GetPanelLevelUp(currentLevel))
                );
                EventMgr.Broadcast(GameEvents.BackpackPanelOpenNotify);
                
            });

            settingCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.TestPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<TestPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                    
                });
            });
        }

        void SetDefaultMainMenuPos(){
            mainTemplate.localScale = Vector3.one;
            attackTemplate.localScale = Vector3.zero;
        }

        void InitAttackTemplate(){
            attackBackCube = attackTemplate.Find("line1/BackCube").GetComponent<Button>();
            area1Cube = attackTemplate.Find("line2/Area1Cube").GetComponent<Button>();

            attackBackCube.onClick.AddListener(()=>{
                mainTemplate.localScale = Vector3.one;
                attackTemplate.localScale = Vector3.zero;
            });

            area1Cube.onClick.AddListener(()=>{
                panelMediator.ShowTwiceConfirmPanel("确定要出击地区1吗?", 10, ()=>{
                    attackInviteRequest.SendRequest(1);
                });
            });
        }

        public void StartAttackCallback(int areaNumber){
            SetDefaultMainMenuPos();
            EventMgr.Broadcast(GameEvents.ShowLoadingPanelNotify);
            switch (areaNumber)
            {
                case 1:
                    sceneMediator.SetScene(new AttackArea1Scene(sceneMediator));
                break;
            }
        }

        public bool _isInTheTeam = false;
        public void IsInTheTeam(bool isInTheTeam){
            if (isInTheTeam && !_isInTheTeam)
            {
                _isInTheTeam = isInTheTeam;
                attackCube.onClick.RemoveAllListeners();
                attackCube.transform.Find("Text").GetComponent<Text>().text = "准备就绪";
                attackCube.onClick.AddListener(()=>{
                    readyAttackRequest.SendRequest();
                });
            }else
            {
                if (!_isInTheTeam && !isInTheTeam)
                {
                    return;
                }
                _isInTheTeam = isInTheTeam;
                attackCube.onClick.RemoveAllListeners();
                attackCube.transform.Find("Text").GetComponent<Text>().text = "取消准备";
                attackCube.onClick.AddListener(()=>{
                    cancelReadyAttackRequest.SendRequest();
                });
                PlayerJoinTeamCallback();
            }
        }

        public void LeaveTeamCallback(){
            attackCube.transform.Find("Text").GetComponent<Text>().text = "出击";
            attackCube.onClick.RemoveAllListeners();
            attackCube.onClick.AddListener(()=>{
                mainTemplate.localScale = Vector3.zero;
                attackTemplate.localScale = Vector3.one;
            });

            PlayerJoinTeamCallback();
        }

        public void PlayerJoinTeamCallback(){
            if (networkMediator.teamMasterPlayerUid == networkMediator.playerSelfUid)
            {
                if (networkMediator.teammateAllReady)
                {
                    area1Cube.onClick.RemoveAllListeners();
                    area1Cube.onClick.AddListener(()=>{
                        panelMediator.ShowTwiceConfirmPanel("有队员未准备好,是否发送提醒队员准备就绪的通知?", 10, ()=>{
                            teamMasterAttackNotifyRequest.SendRequest();
                        });
                    });
                }else
                {
                    area1Cube.onClick.RemoveAllListeners();
                    area1Cube.onClick.AddListener(()=>{
                        panelMediator.ShowTwiceConfirmPanel("确定要出击地区1吗?", 10, ()=>{
                            attackInviteRequest.SendRequest(1);
                        });
                    });
                }
                
            }
        }
    }
}

