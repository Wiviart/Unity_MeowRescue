using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Player")] public Vector2 playerSpawnPoint = new(50, -50);

    [Header("Tsunami")] public Vector2 tsunamiSpawnPoint = new(50, -150);

    [Header("Objects")] public Vector2[] meowPoints;
    public ObjectData[] housePoints;
    public Vector2[] treePoints;
    public Vector2[] obstaclePoints;

    [Header("Map")] public GameObject mapPrefab;
    public Vector2 checkpointPoints = new(50, 400);
    public Vector2 exitPoints = new(50, 1400);
}

[Serializable]
public struct ObjectData
{
    public Vector2 points;
    public Vector3 rotations;
}