using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject startMapPrefab;
    public GameObject tsunamiPrefab;
    public GameObject[] meowPrefabs;

    public LevelData[] levels;
}