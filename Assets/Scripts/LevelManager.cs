using System;
using MeowRescue.Utilities;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameData gameData;
    private LevelData levelData;
    public GameState gameState = GameState.Init;

    private void Awake()
    {
        Instance = this;

        var id = PlayerPrefs.GetInt(ConstTag.LEVEL, 0);
        levelData = gameData.levels[id];
    }

    private void Start()
    {
        var spawner = new Spawner(gameData, levelData);
        spawner.Spawn(SpawnType.Map);
        spawner.Spawn(SpawnType.Player);
        spawner.Spawn(SpawnType.Meows);
        spawner.Spawn(SpawnType.Tsunami);

        gameState = GameState.Playing;
    }
}

public enum GameState
{
    Init,
    Playing,
    GameWin,
    GameOver
}