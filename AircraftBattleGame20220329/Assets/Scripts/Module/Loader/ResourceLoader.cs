using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : ILoader {
   

    //根据路径加载prefab
    public GameObject LoadPrefab(string path,Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject temp = Object.Instantiate(prefab, parent);
        return temp;

    }
    //配置加载
    public void Loadconfig(string path, System.Action<object> complete)
    {
        //todo:使用协成管理器开启协程
    }
    private IEnumerator Config(string path, System.Action<object> complete)
    {
        if(Application.platform !=RuntimePlatform.Android)//非安卓平台文件加载路径
        path = "file://" + path;
        WWW www = new WWW(path);
        yield return www;
        if(www.error != null)
        {
            Debug.LogError("加载配置错误，路径为" + path);
            yield break;

        }
        complete(www.text);
        Debug.Log("文件加载成功，路径为：" + path);
    }
}
