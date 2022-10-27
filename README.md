# Re-TouchGunFire

Rebuild project.

## TODO

修复BattleGunInfoPanelInfo

默认选中主武器

战斗场景的专用选项

---

登陆UI搭建

BackpackPanel的已装备信息简略信息显示，闲置装备Cube排列，装备详细信息显示，排序, 分解


## 已知问题


- 似乎多个资源异步加载时会触发如果AB包没及时卸载就再次尝试加载的Error
```
- The AssetBundle 'D:/Source/Re-TouchGunFire/Assets/StreamingAssets/AbMap/AssetBundle/prefabs' can't be loaded because another AssetBundle with the same files is already loaded.

- Error while getting Asset Bundle: The AssetBundle 'D:/Source/Re-TouchGunFire/Assets/StreamingAssets/AbMap/AssetBundle/prefabs' can't be loaded because another AssetBundle with the same files is already loaded.

- NullReferenceException: Object reference not set to an instance of an object
ReTouchGunFire.Mediators.AbMediator+<AsyncLoadABRes>d__9.MoveNext () (at Assets/Scripts/Mediators/AbMediator.cs:150)

```

## CHANGELOG

> `22.10.27 9:28`
add BattleLittleMenuPanelInfo, BattleLittleMenuPanel. 

> `22.10.27 2:53`
add BattleGunInfoPanelInfo, BattleGunInfoPanel. 

> `22.10.26 3:27`
add AttackArea1PanelInfo, BaseAttackAreaPanelInfo, LoadingPanelInfo. 
add AttackArea1Panel, LoadingPanel. 
something modify. 

> `22.10.25 11:59`
add BackpackPanelInfo. 

> `22.10.25 4:08`
add Equipment, Gun props. 

> `22.10.24 12:23`
改了变量名

> `22.10.23 19:03`
add TestPanel, TestPanelInfo, fix bug and rewrite panelMediator, UIMgr. 

> `22.10.23 2:43`
add PlayerInfoPanelInfo, PlayerPropsPanelInfo. 

> `22.10.22 11.21`
modify for old UI panel. 

> `22.10.22 1:35`
new UI: PlayerInfoPanel, PlayerPropsPanel. 

> `22.10.21 0:12`
add MainMenuPanel. 

> `22.10.19 22:11`
add BackButtonPanel. 

> `22.10.19 5:32`
因为异步加载问题 全部加载资源方式换成同步加载. 
add MainInfoPanel etc. 

> `22.10.18 12:34`
Renamed Mediation to Mediator. 
add EventMgr System. 
UIMgr - PushPanel function fixed. 

> `22.10.17 22:02`
Google.Protobuf problem fixed. 
**First Time For Build Successful.**

> `22.10.17 4:13`
improved AbMediator, SceneMediator, GameLoop etc. 

> `22.10.16 23:49`
add PanelMediator. 
work in progress for InitScene. 

> `22.10.15 23:41`
rewrite something. 
add HotUpdateMediator. 

> `22.10.15 7:10`
add CanvasMediator, LuaMediator, NetworkMediator etc. 
rewrite some enum, GameManager etc. 
add CanvasInfo, RegisterPanelInfo etc. 
add plugin "AssetBundleBrowserPlus". 

> `22.10.14 17:28`
add Mediator Mode , IMediator. 
rewrite Interface. 

> `22.10.13 23:41`
add RequestMgr, IRequest. 

> `22.10.11 22:41`
add XLua, SocketClient etc. 

> `Init / 22.9.24`
null



## 项目结构
```mermaid
graph TB
gl(GameLoop)
gm(GameManager)
upm(UpdateManager:IManager)
sm(SceneManager:IManager)
im(InfoManager:IManager)
um(UIManager:IManager)
om(ObjectManager:IManager)
ii:ii(ItemInfo:IInfo)
oi:ii(ObjectInfo:IInfo)
si:ii(StateInfo:IInfo)
wi:ii(WeaponInfo)
pi:oi(PlayerInfo:ObjectInfo)
ei:oi(EnemyInfo:ObjectInfo)
p:io(Player:IObject)
e:io(Enemy:IObject)
si:ii(SceneInfo:IInfo)
psi:si(PlayerStateInfo)
esi:si(EnemyStateInfo)
ai:ii(ArmorInfo)
ui:ii(UIInfo:IInfo)
xLua
Network
gl-->gm
gm-->upm
gm-->sm
gm-->im
gm-->um
gm-->om
im-->ii:ii
im-->si:ii
im-->oi:ii
im-->ui:ii
oi:ii-->pi:oi
ii:ii-->wi:ii
oi:ii-->ei:oi
ii:ii-->ai:ii
om-->p:io
om-->e:io
si:ii-->psi:si
si:ii-->esi:si
```
## 临时流程指导笔记


0 ~ 90 one 
90 ~ 180 two
-90 ~ 0 four 270 ~ 360
-90 ~ -180 three 180 ~ 270


```