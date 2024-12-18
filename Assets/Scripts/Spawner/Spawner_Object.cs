using UnityEngine;

public class Spawner_Object : MonoBehaviour
{
    [SerializeField] private SpawnerData spawnerData;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        var i = Random.Range(0, spawnerData.prefabs.Length);
        var pf = spawnerData.prefabs[i];
        var pos = transform.position;
        var r = transform.rotation;
        var obj = Instantiate(pf, pos, r);
    }
}