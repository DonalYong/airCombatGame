
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : ViewBase
{
    private int _id;//当前正在操作的飞机id
    private Dictionary<int, List<Sprite>> _planeSprites;//飞机id和对应的sprite
    private Action<int> _switchAction;

    protected override void InitChild() 
    {
        Util.Get("Left").AddListener(()=>Switch(ref _id,-1));
        Util.Get("Right").AddListener(() =>Switch (ref _id,1));
        LoadSprite();
       
    }
    //加载飞机图片
    private void LoadSprite()
    {
        _planeSprites= new Dictionary<int, List<Sprite>>();
        Sprite[] sprites = LoadMgr.Single.LoadAll<Sprite>(Paths.PICTURE_PLAYER_PICTURE_FOLDER);

        foreach (Sprite sprite in sprites)
        {
            string[] idDtata = sprite.name.Split('_');//第一项代表id，第二项代表等级
            int playerId = int.Parse(idDtata[0]);
            if (!_planeSprites.ContainsKey(playerId))
            {
                _planeSprites[playerId] = new List<Sprite>();
            }
            _planeSprites[playerId].Add(sprite);
        }
    }
    
    public override void Show()
    {
        _id = DataMgr.Single.Get<int>(DataKeys.PLANE_ID);//id初始化
        Switch(ref _id, 0);
    }
    private void Switch(ref int id,int direction)
    {
        UpdateId(ref id, direction);
        UpdateSprite(id);
        GameStateModel.Single.SelectedPlaneId = id;
    }
    //更新当前的Id
    private void UpdateId(ref int id, int direction)
    {
        int min = 0;
        int max = _planeSprites.Count;
        id += direction;
        id = id < 0 ? 0 : id >= max ? id = max - 1 : id;

    }
    
    //更新图片
    private void UpdateSprite( int id)
    {
        int level = DataMgr.Single.Get<int>(DataKeys.LEVEL);
        Util.Get("Icon").SetSprite(_planeSprites[id] [level]);
    }

}
