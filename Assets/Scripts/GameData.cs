using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject startMapPrefab;
    public GameObject tsunamiPrefab;
    public GameObject meowSpawnerPrefab;

    public LevelData[] levels;
    public GameObject checkpointPrefab;
    public GameObject exitPrefab;
}