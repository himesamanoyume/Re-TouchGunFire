using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class AbMediator : IMediator
    {
        public AbMediator(){
            Name = "AbMediator";
        }

        public PanelMediator panelMediator;
        AssetBundle prefabsAb;

        private void Start() {
            Init();
        }

        public override void Init()
        {
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            StartCoroutine(LoadPrefabsAb());
        }

        IEnumerator LoadPrefabsAb(){
            UnityWebRequest assetBundle = UnityWebRequestAssetBundle.GetAssetBundle(Application.streamingAssetsPath + abMapPathStr + "prefabs");
            yield return assetBundle.SendWebRequest();
            prefabsAb = DownloadHandlerAssetBundle.GetContent(assetBundle);
            yield return prefabsAb;
            EventMgr.Broadcast(GameEvents.AbLoadEndNotify);
        }

        private const string abMapPathStr = "/AbMap/AssetBundle/";

        /// <summary>
        /// 同步加载ab,不能用于场景
        /// </summary>
        /// <param name="abName"></param>
        /// <param name="resName"></param>
        /// <param name="transform"></param>
        /// <returns></returns>
        public GameObject SyncLoadABRes(string abName, string resName, Transform transform){
            
        // #if UNITY_EDITOR
        //     if(IsLocalLoadType){
        //         // Assets/AssetBundleLocal/prefabs/
        //         GameObject request = AssetDatabase.LoadAssetAtPath<GameObject>(abLocalPathStr + abName + "/" + resName + "/" + resName + ".prefab");
        //         GameObject obj2 = Instantiate(request, transform);
        //         obj2.name = name;
        //         return obj2;
        //     }
        // #endif

            //StreamingAssets/AbMap/AssetBundle/abName
            AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + abMapPathStr + abName);
            GameObject obj = Instantiate(ab.LoadAsset<GameObject>(resName),transform);
            obj.name = resName;
            ab.Unload(false);//卸载单个
            return obj;
        }


        /// <summary>
        /// 同步加载场景
        /// </summary>
        /// <param name="abName"></param>
        /// <param name="resName"></param>
        public void SyncLoadABScene(string abName, string sceneName){
        // #if UNITY_EDITOR
        //     if (IsLocalLoadType)
        //     {
        //         AssetDatabase.LoadAssetAtPath<SceneAsset>(abLocalPathStr + abName + "/" + sceneName + "/" + sceneName + ".unity");
        //         SceneManager.LoadScene(sceneName);
        //         return;
        //     }
        // #endif
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
            SceneManager.LoadSceneAsync(sceneName);
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
        /// 异步加载UI面板,会直接Push该面板
        /// </summary>
        /// <param name="abName"></param>
        /// <param name="panelName"></param>
        /// <param name="transform"></param>
        /// <param name="eUILevel"></param>
        public IEnumerator AsyncLoadABRes(string panelName, Transform transform, EUIPanelType eUIPanelType, EUILevel eUILevel,bool isInsertToList, PanelMediator.AddInfoScriptDel addInfoScriptDel){

            GameObject tobj = prefabsAb.LoadAsset<GameObject>(panelName);
            yield return tobj;
            // ab.Unload(false);
            GameObject obj = Instantiate(tobj, transform);
            yield return obj;
            obj.name = panelName;
            panelMediator.LoadResFromAbMediatorCallback(obj, eUIPanelType, eUILevel, isInsertToList, addInfoScriptDel);

            // UnityWebRequest assetBundle = UnityWebRequestAssetBundle.GetAssetBundle(Application.streamingAssetsPath + abMapPathStr + abName);
            // yield return assetBundle.SendWebRequest();
            // AssetBundle ab = DownloadHandlerAssetBundle.GetContent(assetBundle);
            // yield return ab;
            // GameObject tobj = ab.LoadAsset<GameObject>(panelName);
            // ab.Unload(false);
            // GameObject obj = Instantiate(tobj, transform);
            // obj.name = panelName;
            // panelMediator.PushPanel(eUILevel, obj);
            
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
}

