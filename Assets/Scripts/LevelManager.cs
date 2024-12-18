using System;
using MeowRescue.Data;
using MeowRescue.Utilities;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    private LevelData levelData;
    private int levelIndex;
    public static GameState GameState { private set; get; } = GameState.Init;

    private void Awake()
    {
        Loader.Load(ConstTag.LEVEL, out levelIndex);
        levelData = gameData.levels[levelIndex];
    }

    private void Start()
    {
        var spawner = new Spawner(gameData, levelData);
        spawner.Spawn(SpawnType.Map);
        spawner.Spawn(SpawnType.Player);
        spawner.Spawn(SpawnType.Meows);
        spawner.Spawn(SpawnType.Tsunami);

        GameState = GameState.Playing;

        Observer.Instance.OnGameEnded += GameOver;
    }

    private void GameOver()
    {
        GameState = GameState.GameOver;
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        Saver.Reset();
        print("Game has been reset.");
    }
}

public enum GameState
{
    Init,
    Playing,
    GameOver
}