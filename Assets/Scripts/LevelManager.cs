using System;
using MeowRescue.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CurrencyUI currencyUI;
    private LevelData levelData;
    private int levelIndex;
    public GameState GameState { set; get; } = GameState.Init;

    private void Awake()
    {
        Instance = this;

        levelIndex = PlayerPrefs.GetInt(ConstTag.LEVEL, 0);
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
    }

    public void SetState(GameState state)
    {
        GameState = state;

        switch (state)
        {
            case GameState.GameWin:
                UnlockLevel();
                RestartLevel();
                break;
            case GameState.GameOver:
                RestartLevel();
                break;
        }
    }

    public void UnlockLevel()
    {
        if (levelIndex >= gameData.levels.Length - 1) return;

        levelIndex++;
        PlayerPrefs.SetInt(ConstTag.LEVEL, levelIndex);
        print(levelIndex);
    }

    public void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(scene);
    }

    public void UpdateCurrency(int currency)
    {
        currencyUI.UpdateCurrency(currency);
    }
}

public enum GameState
{
    Init,
    Playing,
    GameWin,
    GameOver
}