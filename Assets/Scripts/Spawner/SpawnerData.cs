using UnityEngine;

namespace MeowRescue.Spawner
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "Scriptable Objects/SpawnerData")]
    public class SpawnerData : ScriptableObject
    {
        public GameObject[] prefabs;
    }
}