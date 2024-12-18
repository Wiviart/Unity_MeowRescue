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
        for (int i = 0; i < 4; i++)
        {
            var pos = Vector3.forward * i * 400;
            var m = levelData.mapPrefab;
            var map = Object.Instantiate(m, pos, m.transform.rotation);

            var id = Random.Range(0, levelData.decorationPrefabs.Length);
            var d = levelData.decorationPrefabs[id];
            var deco = Object.Instantiate(d, pos, d.transform.rotation);
        }

        for (int i = 0; i < levelData.checkpointPoints.Length; i++)
        {
            var cPos = levelData.checkpointPoints[i];
            var checkpointPos = new Vector3(cPos.x, 0, cPos.y);
            var c = gameData.checkpointPrefab;
            var checkpoint = Object.Instantiate(c, checkpointPos, c.transform.rotation);
        }

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