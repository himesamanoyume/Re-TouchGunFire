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

    private const string abMapPathStr = "/AbMap/AssetBundle/";

    /// <summary>
    /// 同步加载ab,不能用于场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    public GameObject SyncLoadABRes(string abName, string resName){
        //"StreamingAssets/AbMap/AssetBundle/`abName`"
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + abName);
        GameObject obj = ab.LoadAsset<GameObject>(resName);

        //卸载全部ab包 true:卸载场景中已经加载的ab包资源 false:只卸载ab包
        //AssetBundle.UnloadAllAssetBundles(false);
        //卸载单个
        ab.Unload(false);
        return Instantiate(obj);
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    public void StartSyncLoadAbScene(string abName, string sceneName){
        StartCoroutine(SyncLoadAbScene(abName, sceneName));
    }

    private IEnumerator SyncLoadAbScene(string abName, string sceneName){
        UnityWebRequest assetBundle = UnityWebRequestAssetBundle.GetAssetBundle(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return assetBundle.SendWebRequest();
        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(assetBundle);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 异步加载ab,不能用于场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="action">拿取资源的委托</param>
    /// <returns></returns>
    public GameObject StartAsyncLoadABRes(string abName, string resName){
        StartCoroutine(AsyncLoadABRes(abName, resName));
        if(tempGameObject != null)
            return tempGameObject;
        else
            return null;
    }
    
    private GameObject tempGameObject = null;
    private IEnumerator AsyncLoadABRes(string abName, string resName){
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return abcr;
        AssetBundleRequest abr = abcr.assetBundle.LoadAssetAsync<GameObject>(resName);
        yield return abr;
        tempGameObject = Instantiate(abr.asset as GameObject);
        // return Instantiate(abr.asset as GameObject);
    }

    /// <summary>
    /// 异步加载ab,用于加载场景
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="sceneName"></param>
    public void StartAsyncLoadABScene(string abName, string sceneName){
        StartCoroutine(AsyncLoadABScene(abName, sceneName));
    }

    private IEnumerator AsyncLoadABScene(string abName, string sceneName){
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return abcr;
        AssetBundleRequest abr = abcr.assetBundle.LoadAssetAsync(sceneName);
        yield return abr;
        SceneManager.LoadScene(sceneName);
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
