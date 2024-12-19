using MeowRescue.Data;
using UnityEngine;

namespace MeowRescue.Utilities
{
    public class LevelGeneration
    {
        private const int meowMultiplier = 1;
        private const int obstacleMultiplier = 5;
        private readonly LevelData baseLevelData;

        public LevelGeneration(LevelData baseLevelData)
        {
            this.baseLevelData = baseLevelData;
        }

        public void GenerateLevels(int levelCount)
        {
            for (int i = 0; i < levelCount; i++)
            {
                var newLevel = ScriptableObject.CreateInstance<LevelData>();

                newLevel.name = "Level " + i;
                newLevel.playerSpawnPoint = baseLevelData.playerSpawnPoint;
                newLevel.tsunamiSpawnPoint = baseLevelData.tsunamiSpawnPoint;
                newLevel.meowPoints = new Vector2[baseLevelData.meowPoints.Length + meowMultiplier * i];
                newLevel.housePoints = baseLevelData.housePoints;
                newLevel.treePoints = baseLevelData.treePoints;
                newLevel.obstaclePoints = new Vector2[baseLevelData.obstaclePoints.Length + obstacleMultiplier * i];
                newLevel.mapPrefab = baseLevelData.mapPrefab;
                newLevel.checkpointPoints = baseLevelData.checkpointPoints;
                newLevel.exitPoints = baseLevelData.exitPoints;

                GeneratePoints(newLevel.meowPoints, 20, 80, 40, 400);
                GeneratePoints(newLevel.obstaclePoints, 10, 100, 0, 400);

                SaveLevel(newLevel);
            }
        }

        private void GeneratePoints(Vector2[] points, int minX, int maxX, int minY, int maxY)
        {
            for (int j = 0; j < points.Length; j++)
            {
                var x = Random.Range(minX, maxX);
                var y = Random.Range(minY, maxY);
                points[j] = new Vector2(x, y);
            }
        }

        private void SaveLevel(LevelData levelData)
        {
#if UNITY_EDITOR

            var path = "Assets/Resources/Levels/" + levelData.name + ".asset";
            UnityEditor.AssetDatabase.CreateAsset(levelData, path);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
    }
}