using UnityEngine;

namespace MeowRescue.Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
    public class GameData : ScriptableObject
    {
        public GameObject playerPrefab;
        public GameObject startMapPrefab;
        public GameObject tsunamiPrefab;
        public GameObject meowSpawnerPrefab;
        public GameObject houseSpawnerPrefab;
        public GameObject treeSpawnerPrefab;
        public GameObject obstacleSpawnerPrefab;

        public LevelData baseLevelData;
        public LevelData[] levels;
        public GameObject checkpointPrefab;
        public GameObject exitPrefab;
    }
}