using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData data;

    private void Start()
    {
        var spawner = new Spawner(data);
        spawner.Spawn(SpawnType.Player);
        spawner.Spawn(SpawnType.Meows);
        spawner.Spawn(SpawnType.Map);
    }
}