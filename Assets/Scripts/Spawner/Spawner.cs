using MeowRescue.Utilities.Spawner;
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

public class Spawner : ASpawner
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
        Spawn(gameData.playerPrefab, levelData.playerSpawnPoint);
    }

    private void SpawnMeows()
    {
        // Spawn Meow Spawners
        for (int i = 0; i < levelData.meowPoints.Length; i++)
        {
            var randomPoint = Random.insideUnitCircle * 20;
            var spawnPoint = levelData.meowPoints[i] + randomPoint;
            Spawn(gameData.meowSpawnerPrefab, spawnPoint);
        }
    }

    private void SpawnStartMap()
    {
        var map = Object.Instantiate(gameData.startMapPrefab);
    }

    private void SpawnMap()
    {
        for (int i = 0; i < 4; i++)
        {
            var pos = Vector3.forward * i * 400;
            Spawn(levelData.mapPrefab, pos);
            SpawnDecorations(pos);
        }

        Spawn(gameData.checkpointPrefab, levelData.checkpointPoints);
        Spawn(gameData.exitPrefab, levelData.exitPoints);
    }

    private void SpawnTsunami()
    {
        Spawn(gameData.tsunamiPrefab, levelData.tsunamiSpawnPoint);
    }

    private void SpawnDecorations(Vector3 pos)
    {
        // Spawn House Spawners
        for (int i = 0; i < levelData.housePoints.Length; i++)
        {
            var spawnPoint = levelData.housePoints[i].points;
            var r = levelData.housePoints[i].rotations;
            var obj = Spawn(gameData.houseSpawnerPrefab, spawnPoint, r);
            obj.transform.position += pos;
        }

        // Spawn Tree Spawners
        for (int i = 0; i < levelData.treePoints.Length; i++)
        {
            var spawnPoint = levelData.treePoints[i];
            var obj = Spawn(gameData.treeSpawnerPrefab, spawnPoint);
            obj.transform.position += pos;
        }

        // Spawn Obstacle Spawners
        for (int i = 0; i < levelData.obstaclePoints.Length; i++)
        {
            var spawnPoint = levelData.obstaclePoints[i];
            var obj = Spawn(gameData.obstacleSpawnerPrefab, spawnPoint);
            obj.transform.position += pos;
        }
    }
}