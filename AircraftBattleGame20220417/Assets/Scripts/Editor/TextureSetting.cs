using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class TextureSetting : AssetPostprocessor
{
    private static FolderData _playerData;
   private void OnPreprocessTexture()
    {
        NamingConventions();
        SetTexturePara();
    }
    //命名规范
    private void NamingConventions()
    {
        PlayerNaming();
    }
    //玩家飞机命名
    private void PlayerNaming()
    {
        if (assetPath.Contains(Paths.PICTURE_PLAYER_PICTURE_FOLDER))//判定导入资源是否在某一个具体路径下
        {
            string name =Path.GetFileNameWithoutExtension(Path.GetFileName(assetPath));//获取当前路径的文件名并去除拓展名
            string pattern = "^[0-9]+_[0-9]+$";//命名模板
            Match result = Regex.Match(name, pattern);
            if (result.Value=="")
            {
                if (_playerData==null)
                {
                    _playerData = new FolderData();
                    _playerData.FolderPath = Paths.PICTURE_PLAYER_PICTURE_FOLDER;
                    _playerData.NameTip = "：0_0";
                }
                Debug.LogError("当前导入资源名称错误，名称为：" + name);
                NameMgrWindowData.Add(_playerData, assetPath);
                NameMgrWindow.ShowWindow();
                
                
            } 
            
        }
    }
    //设置图片参数
    private void SetTexturePara()
    {
        TextureImporter importer = (TextureImporter)assetImporter;//转化为图片导入器
        importer.textureType = TextureImporterType.Sprite;//所有导入图片设置精灵类型
        importer.mipmapEnabled = false;//是否生成小图
    }
    
}
