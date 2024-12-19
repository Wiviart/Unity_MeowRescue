using MeowRescue.Data;
using MeowRescue.Utilities;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameData gameData;
    private LevelData levelData;
    private int levelIndex;
    public GameState GameState { private set; get; } = GameState.Init;

    private void Awake()
    {
        Instance = this;

        Loader.Load(ConstTag.LEVEL, out levelIndex);
        levelData = gameData.levels[levelIndex];
        Debug.Log("Level: " + levelIndex);
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
        Observer.Instance.OnGameWin += () =>
        {
            GameState = GameState.GameWin;
            UnlockLevel();
        };
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

    private void UnlockLevel()
    {
        if (levelIndex >= gameData.levels.Length - 1) return;

        levelIndex++;
        PlayerPrefs.SetInt(ConstTag.LEVEL, levelIndex);
        print("Level Unlocked: " + levelIndex);
    }

    public int MeowCount()
    {
        return levelData.meowPoints.Length;
    }
}

public enum GameState
{
    Init,
    Playing,
    GameWin,
    GameOver
}