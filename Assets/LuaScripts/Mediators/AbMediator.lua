AbMediator = {}

local util = require 'xlua.util'
local panelMediator
local prefabsAb

function AbMediator:Init()
    panelMediator = CS.GameLoop.Instance:GetMediator(typeof(CS.ReTouchGunFire.Mediators.PanelMediator))
    prefabsAb = CS.UnityEngine.AssetBundle
end

local LoadPrefabsAb = util.cs_generator(function ()
    local assetBundle = CS.UnityEngine.Networking.UnityWebRequestAssetBundle:GetAssetBundle(CS.UnityEngine.Application.streamingAssetsPath .. '/AbMap/AssetBundle/' .. 'prefabs')

    coroutine.yield(assetBundle:SendWebRequest())
    prefabsAb = CS.UnityEngine.DownloadHandlerAssetBundle.GetContent(assetBundle)
    coroutine.yield(prefabsAb)

    CS.EventMgr.Broadcast(CS.GameEvents.AbLoadEndNotify)
end)

function AbMediator:FirstTimeSyncLoadABRes(abName, resName, transform)
    local ab = CS.UnityEngine.AssetBundle:LoadFromFile(CS.UnityEngine.Application.streamingAssetsPath .. '/AbMap/AssetBundle/' .. abName)
    
    local obj = CS.UnityEngine.Object.Instantiate(ab:LoadAsset(resName, transform, typeof(CS.UnityEngine.GameObject)))

    obj.name = resName
    ab:Unload(false)
    return obj
end

function AbMediator:SyncLoadAbScene(abName, sceneName)
    local ab = CS.UnityEngine.AssetBundle:LoadFromFile(CS.UnityEngine.Application.streamingAssetsPath .. '/AbMap/AssetBundle/' .. abName)

    CS.UnityEngine.SceneManager.LoadScene(sceneName)
    ab:Unload(false)
end

local AsyncLoadABRes = util.cs_generator(function (abName, resName, transform)
    local assetBundle = CS.UnityEngine.UnityWebRequestAssetBundle.GetAssetBundle(CS.UnityEngine.Application.streamingAssetsPath .. '/AbMap/AssetBundle/' .. abName)

    coroutine.yield(assetBundle:SendWebRequest())

    local ab = CS.UnityEngine.DownloadHandlerAssetBundle.GetContent(resName)
    coroutine.yield(ab)
    local tobj = ab:LoadAsset(resName, typeof(CS.UnityEngine.GameObject))
    ab:Unload(false)
    local obj = CS.UnityEngine.Object.Instantiate(tobj, transform)
end)

local AsyncLoadABRes = util.cs_generator(function (panelName, transform, eUIPanelType, eUILevel, isInsertToList, addInfoScriptDel)
    
end)