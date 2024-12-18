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
        var pos = levelData.playerSpawnPoint;
        var pPos = new Vector3(pos.x, 0, pos.y);
        var p = gameData.playerPrefab;
        var r = p.transform.rotation;
        var player = Object.Instantiate(p, pPos, r);
    }

    private void SpawnMeows()
    {
        for (int i = 0; i < levelData.meowPoints.Length; i++)
        {
            var randomPoint = Random.insideUnitCircle * 20;
            var spawnPoint = levelData.meowPoints[i] + randomPoint;
            var pos = new Vector3(spawnPoint.x, 0, spawnPoint.y);
            var pf = gameData.meowSpawnerPrefab;
            var meow = Object.Instantiate(pf, pos, Quaternion.identity);
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
            var m = levelData.mapPrefab;
            var map = Object.Instantiate(m, pos, m.transform.rotation);

            var d = levelData.decorationPrefab;
            var deco = Object.Instantiate(d, pos, d.transform.rotation);
        }

        var cPos = levelData.checkpointPoints;
        var checkpointPos = new Vector3(cPos.x, 0, cPos.y);
        var c = gameData.checkpointPrefab;
        var checkpoint = Object.Instantiate(c, checkpointPos, c.transform.rotation);

        var ePos = levelData.exitPoints;
        var exitPos = new Vector3(ePos.x, 0, ePos.y);
        var e = gameData.exitPrefab;
        var exit = Object.Instantiate(e, exitPos, e.transform.rotation);
    }

    private void SpawnTsunami()
    {
        var pos = new Vector3(levelData.tsunamiSpawnPoint.x, 0, levelData.tsunamiSpawnPoint.y);
        var tsunami = Object.Instantiate(gameData.tsunamiPrefab, pos, Quaternion.identity);
    }
}