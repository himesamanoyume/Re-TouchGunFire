using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AbMediation : IMediation
{
    public AbMediation(){
        Name = "AbMediation";
    }

    public UIMgr m_uiMgr = null;

    public override void Init()
    {
        m_uiMgr = GameLoop.Instance.gameManager.UIMgr;
    }

    private const string abMapPathStr = "/AbMap/AssetBundle/";

    /// <summary>
    /// 同步加载ab,不能用于场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public GameObject SyncLoadABRes(string abName, string resName, Transform transform){
        //"StreamingAssets/AbMap/AssetBundle/`abName`"
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + abName);
        GameObject tobj = ab.LoadAsset<GameObject>(resName);

        //卸载全部ab包 true:卸载场景中已经加载的ab包资源 false:只卸载ab包
        //AssetBundle.UnloadAllAssetBundles(false);
        GameObject obj = Instantiate(tobj,transform);
        obj.name = name;
        ab.Unload(false);//卸载单个
        
        return obj;
    }

    /// <summary>
    /// 同步加载UI面板
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="transform"></param>
    /// <param name="eUILevel"></param>
    public void SyncLoadABUIRes(string abName, string resName, Transform transform, EUILevel eUILevel){
        
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + abName);
        GameObject obj = Instantiate(ab.LoadAsset<GameObject>(resName),transform);
        obj.name = resName;
        m_uiMgr.PushPanel(eUILevel, obj);
        
        ab.Unload(false);
    }

    /// <summary>
    /// 同步加载场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    public void SyncLoadABScene(string abName, string sceneName){
        
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + abName);
        SceneManager.LoadScene(sceneName);
        ab.Unload(false);
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    public IEnumerator AsyncLoadAbScene(string abName, string sceneName){
        UnityWebRequest assetBundle = UnityWebRequestAssetBundle.GetAssetBundle(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return assetBundle.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(assetBundle);
        yield return ab;
        SceneManager.LoadScene(sceneName);
        ab.Unload(false);
    }

    /// <summary>
    /// 异步加载ab物体,不能用于场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="transform"></param>
    public IEnumerator AsyncLoadABRes(string abName, string resName, Transform transform){

        UnityWebRequest assetBundle = UnityWebRequestAssetBundle.GetAssetBundle(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return assetBundle.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(assetBundle);
        yield return ab;
        GameObject tobj = ab.LoadAsset<GameObject>(resName);
        ab.Unload(false);
        GameObject obj = Instantiate(tobj, transform);
        obj.name = resName;
    }

    /// <summary>
    /// 异步加载UI面板
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="transform"></param>
    /// <param name="eUILevel"></param>
    public IEnumerator AsyncLoadABUIRes(string abName, string resName, Transform transform, EUILevel eUILevel){

        UnityWebRequest assetBundle = UnityWebRequestAssetBundle.GetAssetBundle(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return assetBundle.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(assetBundle);
        yield return ab;
        GameObject tobj = ab.LoadAsset<GameObject>(resName);
        ab.Unload(false);
        GameObject obj = Instantiate(tobj, transform);
        obj.name = resName;
        m_uiMgr.PushPanel(eUILevel, obj);
        
    }

    /// <summary>
    /// 获取ab依赖
    /// </summary>
    public void Depend(){
        AssetBundle abMain = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + "AssetBundle");
        //存疑
        AssetBundleManifest abManifest = abMain.LoadAsset<AssetBundleManifest>("AssetBundleManifest"); // something uncertain
        string[] str = abManifest.GetAllDependencies("prefabs"); // something uncertain
        //end
    }

}
