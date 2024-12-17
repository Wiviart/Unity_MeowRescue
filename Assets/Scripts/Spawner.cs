using System;
using Unity.AI.Navigation;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public enum SpawnType
{
    Player,
    Meows,
    Map,
    Tsunami
}

public class Spawner
{
    private readonly GameData gameData;
    private readonly LevelData levelData;

    public Spawner(GameData gameData, LevelData levelData)
    {
        this.gameData = gameData;
        this.levelData = levelData;
        
        SpawnStartMap();
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
            case SpawnType.Tsunami:
                SpawnTsunami();
                break;
            default:
                break;
        }
    }

    private void SpawnPlayer()
    {
        var pos = new Vector3(levelData.playerSpawnPoint.x, 0, levelData.playerSpawnPoint.y);
        var player = Object.Instantiate(gameData.playerPrefab, pos, Quaternion.identity);
    }

    private void SpawnMeows()
    {
        for (int i = 0; i < levelData.meowSpawnPoints.Length; i++)
        {
            var index = Random.Range(0, gameData.meowPrefabs.Length);
            var randomPoint = Random.insideUnitCircle * 20;
            var spawnPoint = levelData.meowSpawnPoints[i] + randomPoint;
            var pos = new Vector3(spawnPoint.x, 0, spawnPoint.y);
            var pf = gameData.meowPrefabs[index];
            var meow = Object.Instantiate(pf, pos, Quaternion.identity);
        }
    }

    private void SpawnStartMap()
    {
        var map = Object.Instantiate(gameData.startMapPrefab);
    }

    private void SpawnMap()
    {
        var map = Object.Instantiate(levelData.mapPrefab);
        var deco = Object.Instantiate(levelData.decorationPrefab);
        // var surface = map.GetComponent<NavMeshSurface>();
        // surface.BuildNavMesh();
    }
    
    private void SpawnTsunami()
    {
        var pos = new Vector3(levelData.tsunamiSpawnPoint.x, 0, levelData.tsunamiSpawnPoint.y);
        var tsunami = Object.Instantiate(gameData.tsunamiPrefab, pos, Quaternion.identity);
    }
}