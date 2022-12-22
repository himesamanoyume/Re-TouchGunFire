
using UnityEngine;
using XLua;

[LuaCallCSharp]
public enum EUIPanelType
{
    Null,
    [Tooltip("初始化面板")]
    InitPanel,
    [Tooltip("测试面板")]
    TestPanel,
    [Tooltip("加载中面板")]
    LoadingPanel,
    [Tooltip("热更新面板")]
    HotUpdatePanel,
    [Tooltip("登陆面板")]
    LoginPanel,
    [Tooltip("注册面板")]
    RegisterPanel,
    [Tooltip("主菜单面板")]
    MainMenuPanel,
    [Tooltip("顶部信息面板")]
    MainInfoPanel,
    [Tooltip("返回按钮面板")]
    BackButtonPanel,
    [Tooltip("玩家属性面板")]
    PlayerPropsPanel,
    [Tooltip("玩家信息面板")]
    PlayerInfoPanel,
    [Tooltip("背包面板")]
    BackpackPanel,
    [Tooltip("出击地区面板")]
    AttackAreaPanel,
    [Tooltip("出击状态武器信息面板")]
    BattleGunInfoPanel,
    [Tooltip("出击状态小菜单面板")]
    BattleLittleMenuPanel,
    [Tooltip("出击状态玩家自身血量护甲信息面板")]
    PlayerCurrentStatePanel,
    [Tooltip("二次确认面板")]
    TwiceConfirmPanel,
    [Tooltip("登陆注册面板")]
    LoginRegisterPanel,
    [Tooltip("提示通知面板")]
    NotifyPanel,
    [Tooltip("好友列表面板")]
    FriendsPanel,
    [Tooltip("队伍当前状态面板")]
    PartyCurrentStatePanel,
    [Tooltip("商店面板")]
    ShopPanel,
}
