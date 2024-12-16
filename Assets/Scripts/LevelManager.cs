using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData data;

    private void Start()
    {
        var spawner = new Spawner(data);
        spawner.Spawn(true);
        spawner.Spawn();
    }
}