using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paths 
{
    //预制体路径
    private const string PREFAB_FOLDER = "Prefab/";
    private const string UI_FOLDER = PREFAB_FOLDER + "UI/";
    public const string START_VIEW = UI_FOLDER + "StartView";
    public const string SELECTED_HERO_VIEW = UI_FOLDER + "SelectedHeroView";
    public const string STRENGTHEN_VIEW = UI_FOLDER + "StrengthenView";
    public const string PREFAB_LEVELS_VIEW = UI_FOLDER + "LevelsView";
    public const string PREFAB_LEVEL_ITEM = UI_FOLDER + "LevelItem";
    public const string PREFAB_PROPERTY_ITEM = UI_FOLDER + "PropertyItem";
    public const string PREFAB_DIALOG = UI_FOLDER + "Dialog";
    public const string PREFAB_LOADING_VIEW = UI_FOLDER + "LoadingView";
    public const string PREFAB_GAME_UI_VIEW = UI_FOLDER + "GameUI";
    public const string PREFAB_LIFE_ITEM_VIEW = UI_FOLDER + "LifeItem";
    public const string PREFAB_PAUSE_VIEW = UI_FOLDER + "GamePauseView";

    //图片路径
    private const string PICTURE_FOLDER = "Picture/";
    public const string PICTURE_PLAYER_PICTURE_FOLDER = PICTURE_FOLDER + "Player/";
    public const string PICTURE_MAP_FOLDER = PICTURE_FOLDER + "Map/";
    public const string PICTURE_EFFECT_FOLDER = PICTURE_FOLDER + "Effect/";
    public const string PICTURE_PLANE_DESTROY_FOLDER = PICTURE_EFFECT_FOLDER + "PlaneDestroy/";

    //配置路径
    public static readonly string CONFIG_FOLDER = Application.streamingAssetsPath + "/Config";
    public static readonly string INIT_PLABE_CONFIG = CONFIG_FOLDER + "/InitPlane.json";

}
