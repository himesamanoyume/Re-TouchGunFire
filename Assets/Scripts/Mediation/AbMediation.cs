using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbMediation : IMediation
{
    public AbMediation(MediationMgr mediationMgr) : base(mediationMgr){
        Name = "AbMediation";
    }

    private const string abMapPathStr = "/AbMap/AssetBundle/";

    /// <summary>
    /// 同步加载ab
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    public GameObject SyncLoadAB(string abName, string resName){
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + abName);
        GameObject obj = ab.LoadAsset<GameObject>(resName);

        //卸载全部ab包 true:卸载场景中已经加载的ab包资源 false:只卸载ab包
        //AssetBundle.UnloadAllAssetBundles(false);
        //卸载单个
        ab.Unload(false);
        return Instantiate(obj);
    }

    /// <summary>
    /// 异步加载ab
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public IEnumerator AsyncLoadABRes(string abName, string resName){
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + abMapPathStr + abName);
        yield return abcr;
        AssetBundleRequest abr = abcr.assetBundle.LoadAssetAsync<GameObject>(resName);
        yield return abr;
        Instantiate(abr.asset as GameObject);
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
