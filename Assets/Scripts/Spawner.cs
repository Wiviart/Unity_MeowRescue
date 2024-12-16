using UnityEngine;

public class Spawner
{
    private readonly LevelData data;

    public Spawner(LevelData data)
    {
        this.data = data;
    }

    public void Spawn(bool isPlayer = false)
    {
        switch (isPlayer)
        {
            case true:
                SpawnPlayer();
                break;
            default:
                SpawnMeows();
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
        for (int i = 0; i < data.spawnPoints.Length; i++)
        {
            var index = Random.Range(0, data.meowPrefabs.Length);
            var randomPoint = Random.insideUnitCircle * 20;
            var spawnPoint = data.spawnPoints[i] + randomPoint;
            var pos = new Vector3(spawnPoint.x, 0, spawnPoint.y);
            var pf = data.meowPrefabs[index];
            var meow = Object.Instantiate(pf, pos, Quaternion.identity);
        }
    }
}