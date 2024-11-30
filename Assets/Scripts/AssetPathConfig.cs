using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPathConfig
{
    /// <summary>
    /// 游戏资源总路径
    /// </summary>
    public const string GAMEDATA = "Assets/GameData/";
    /// <summary>
    /// 游戏模块资源路径
    /// </summary>
    public const string GAME = GAMEDATA + "Game/";
    /// <summary>
    /// 游戏预制体资源路径
    /// </summary>
    public const string GAME_PREFABS = GAME + "Prefabs/";
    /// <summary>
    /// 游戏英雄预制体资源路径
    /// </summary>
    public const string GAME_PREFABS_HERO = GAME_PREFABS + "Hero/";
    /// <summary>
    /// 大厅资源路径
    /// </summary>
    public const string HALL = GAMEDATA + "Hall/";
}