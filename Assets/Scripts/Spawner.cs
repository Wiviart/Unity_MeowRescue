using System;
using Unity.AI.Navigation;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public enum SpawnType
{
    Player,
    Meows,
    Map
}

public class Spawner
{
    private readonly LevelData data;

    public Spawner(LevelData data)
    {
        this.data = data;
    }

    public void Spawn(SpawnType type)
    {
        switch (type)
        {
            case SpawnType.Player:
                SpawnPlayer();
                break;
            case SpawnType.Map:
                SpawnMap();
                break;
            case SpawnType.Meows:
                SpawnMeows();
                break;
            default:
                break;
        }
    }

    private void SpawnPlayer()
    {
        var pos = new Vector3(data.playerSpawnPoint.x, 0, data.playerSpawnPoint.y);
        var player = Object.Instantiate(data.playerPrefab, pos, Quaternion.identity);
    }

    private void SpawnMeows()
    {
        for (int i = 0; i < data.meowSpawnPoints.Length; i++)
        {
            var index = Random.Range(0, data.meowPrefabs.Length);
            var randomPoint = Random.insideUnitCircle * 20;
            var spawnPoint = data.meowSpawnPoints[i] + randomPoint;
            var pos = new Vector3(spawnPoint.x, 0, spawnPoint.y);
            var pf = data.meowPrefabs[index];
            var meow = Object.Instantiate(pf, pos, Quaternion.identity);
        }
    }

    private void SpawnMap()
    {
        var map = Object.Instantiate(data.mapPrefab);
        var surface = map.GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }
}