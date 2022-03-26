using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TextureSetting : AssetPostprocessor
{
   private void OnPreprocessTexture()
    {
        TextureImporter importer = (TextureImporter)assetImporter;//转化为图片导入器
        importer.textureType = TextureImporterType.Sprite;//所有导入图片设置精灵类型
    }
    
}
