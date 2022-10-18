using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EUIPanelType
{
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
    BackButtonPanel

}
