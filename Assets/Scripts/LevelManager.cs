using System;
using System.Threading.Tasks;
using MeowRescue.Data;
using MeowRescue.Spawner;
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
        gameData.levels = Resources.LoadAll<LevelData>("Levels");
        SortLevels(gameData.levels);

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

    void SortLevels(LevelData[] levels)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            for (int j = i + 1; j < levels.Length; j++)
            {
                if (string.Compare(levels[i].name, levels[j].name, StringComparison.Ordinal) > 0)
                {
                    (levels[i], levels[j]) = (levels[j], levels[i]);
                }
            }
        }
    }

    private void GameOver()
    {
        GameState = GameState.GameOver;
    }

    [ContextMenu("Reset Game")]
    private void ResetGame()
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

    [ContextMenu("Create Levels")]
    private void CreateLevels()
    {
        var spawner = new LevelGeneration(gameData.baseLevelData);
        spawner.GenerateLevels(10);
    }
}

public enum GameState
{
    Init,
    Playing,
    GameWin,
    GameOver
}