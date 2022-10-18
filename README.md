# Re-TouchGunFire

Rebuild project.

## TODO

AB包加载区分(编辑器模式,发布模式)

## 已知问题



## CHANGELOG

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
## 临时运行流程指导示意图
```mermaid
graph TB

a(Health.cs中UnityAction OnDie)
b(血量为0时OnDie?.Invoke)
c(Player.cs中m_Health.OnDie += OnDie)
d(Player.cs中OnDie函数 Broadcast Events.PlayerDeathEvent)
e(GameFlowManager.cs中Awake中AddListener PlayerDeathEvent OnPlayerDeath)
f(Events.cs中PlayerDeathEvent)
g(OnPlayerDeath PlayerDeathEvent evt => EndGame false)

f-->d
d-->c
a-->c
g-->f
a-->b
b-->g
e-->f
c-->g
```