using MeowRescue.Data;
using MeowRescue.Utilities;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    private LevelData levelData;
    private int levelIndex;
    public static GameState GameState { private set; get; } = GameState.Init;
    private int meowCount = 0;

    private void Awake()
    {
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
        Observer.Instance.OnGameFinished += GameFinished;
        Observer.Instance.OnMeowCatched += CountMeow;
        
        Observer.Instance.MeowChanged(meowCount, levelData.meowPoints.Length);
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

    private void GameFinished(int caught)
    {
        if (caught == levelData.meowPoints.Length)
            Observer.Instance.GameWin();
        else
            Observer.Instance.GameEnded();
    }

    private void CountMeow()
    {
        meowCount++;
        Observer.Instance.MeowChanged(meowCount, levelData.meowPoints.Length);
    }
}

public enum GameState
{
    Init,
    Playing,
    GameWin,
    GameOver
}