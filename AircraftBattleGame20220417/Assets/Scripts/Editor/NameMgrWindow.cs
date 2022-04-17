using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NameMgrWindow : EditorWindow
{
    private Dictionary<string, string> _namesDic = new Dictionary<string, string>();
   public static void ShowWindow()
    {
        EditorWindow.GetWindow<NameMgrWindow>();
    }

    //弹窗内容显示
    private void OnGUI()
    {
        GUILayout.Label("资源名称管理器");

        NameMgrWindowData.UpdateData();

        
        foreach (KeyValuePair<FolderData,List<string>> pair  in NameMgrWindowData.SpriteDic)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label("路径", GUILayout.MaxWidth(50)); ;
            GUILayout.Label(pair.Key.FolderPath, GUILayout.MaxWidth(150));
            GUILayout.Label("范列：", GUILayout.MaxWidth(50));
            GUILayout.Label(pair.Key.NameTip, GUILayout.MaxWidth(150));

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            foreach (string path in pair.Value)
            {
                GUILayout.BeginVertical();

                Texture2D texture2D = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                GUILayout.Box(texture2D,GUILayout.Height(80),GUILayout.Width(80));
                //重命名
                string name = Path.GetFileNameWithoutExtension(path);
                if (!_namesDic.ContainsKey(name))
                {
                    _namesDic[name] = name;
                }
                GUILayout.BeginHorizontal();
                string nameTemp = GUILayout.TextArea(name, GUILayout.Width(40));
                if (GUILayout.Button("确认",GUILayout.Width(40)))
                {
                    if (name != _namesDic[name])
                    {
                        ChangeFileName(name, _namesDic[name], path);
                        _namesDic.Remove(name);
                    }
                    AssetDatabase.Refresh();
                }
                GUILayout.EndHorizontal();

                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }
     
    }

    private void ChangeFileName(string sourceName,string destname,string path)
    {
        string desPath = path.Replace(sourceName, destname);
        if (File.Exists(desPath))
        {
            Debug.LogError("当前文件名已经存在了");
        }
        else
        {
            File.Move(path, desPath);
        }
       
    }
}
//
public class NameMgrWindowData
{
    public static Dictionary<FolderData, List<string>> SpriteDic = new Dictionary<FolderData, List<string>>();
    public  static void Add(FolderData key, string value )
    {
        if (!SpriteDic.ContainsKey(key))
        {
            SpriteDic[key] = new List<string>();
        }
                
        SpriteDic[key].Add(value);
    }
    //更新数据
    public static  void UpdateData()
    {
        foreach (KeyValuePair<FolderData,List<string>> pair in SpriteDic)
        {
            int count = pair.Value.Count;
            for (int i = 0; i < count; i++)
            {
                if (!File.Exists(pair.Value[i]))
                {
                    pair.Value.Remove(pair.Value[i]);
                    i--;
                }

            }
        }
    }
}

public class FolderData
{
    public string FolderPath;
    public string NameTip;
    
}
