using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData", menuName = "Scriptable Objects/SpawnerData")]
public class LevelData : ScriptableObject
{
    [Header("Player")] 
    public GameObject playerPrefab;
    public Vector2 playerSpawnPoint = new Vector2(50, -50);

    [Header("Meow")] 
    public GameObject[] meowPrefabs;
    public Vector2[] spawnPoints;
}