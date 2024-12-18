using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Player")] public Vector2 playerSpawnPoint = new(50, -50);

    [Header("Tsunami")] public Vector2 tsunamiSpawnPoint = new(50, -150);

    [Header("Meow")] public Vector2[] meowSpawnPoints;

    [Header("Map")] public GameObject mapPrefab;
    public GameObject[] decorationPrefabs;
    public Vector2 checkpointPoints = new(50, 400);
    public Vector2 exitPoints = new(50, 1400);
}