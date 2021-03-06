using System.Linq;
using UnityEngine;
using EventController;
using System;
using UnityEngine.SceneManagement;

public class AssetsManager : Singleton<AssetsManager>
{
    #region 移动游戏对象到场景
    public void MoveGameObjectToScene(GameObject go, string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Scene scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.MoveGameObjectToScene(go, scene);
        }
    }
    #endregion

    #region 加载场景
    public void LoadSceneAsync(string sceneName, Action<AsyncOperation> cb = null, LoadSceneMode mode = LoadSceneMode.Single)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, mode);
            cb?.Invoke(asyncOperation);
            asyncOperation.completed += (AsyncOperation ao) =>
            {
                Scene scene = SceneManager.GetSceneByName(sceneName);
                SceneManager.SetActiveScene(scene);
                cb?.Invoke(asyncOperation);
            };
        }
    }
    public void UnLoadSceneAsync(string sceneName, Action<float> cb = null)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
            asyncOperation.completed += (AsyncOperation ao) =>
            {
                cb?.Invoke(asyncOperation.progress);
            };
        }
    }
    #endregion

    #region 加载资源
    /// <summary> 
    /// 加载ab包中的资源，返回T
    /// path = sceneName/folderName/assetName
    /// scnenName 打包资源的第一层文件夹名称
    /// folderName 打包资源的第二层文件夹名称
    /// assetName 资源名称
    /// </summary>
    public T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
        if (Root.IsLoadAB)
        {
            string[] names = path.Split('/');
            return AssetBundleManager.Instance.LoadAsset<T>(names[0], names[1], names[names.Length - 1]);
        }
        else
        {
            return Resources.Load<T>(string.Format("AssetsFolder/{0}", path));
        }
    }
    #endregion
}