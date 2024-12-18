using System;

namespace MeowRescue.Utilities
{
    public class Observer : Singleton<Observer>
    {
        public Action<int> OnGoldChanged;
        public Action<float, int> OnSpeedChanged;
        public Action<StatsType> OnPlayerUpgradeChanged;
        public Action<GameState> OnGameStateChanged;
        public Action OnGameInitialized;
        public Action OnGameStarted;
        public Action OnGameEnded;
        public Action OnGameWin;
        public Action<float> OnScoreChanged;

        public void GoldChanged(int gold)
        {
            OnGoldChanged?.Invoke(gold);
        }

        public void PlayerUpgradeChanged(StatsType upgradeType)
        {
            OnPlayerUpgradeChanged?.Invoke(upgradeType);
        }

        public void GameEnded()
        {
            OnGameEnded?.Invoke();
        }

        public void GameWin()
        {
            OnGameWin?.Invoke();
        }

        public void ScoreChanged(float distance)
        {
            OnScoreChanged?.Invoke(distance);
        }

        public void SpeedChanged(float speed, int cost)
        {
            OnSpeedChanged?.Invoke(speed, cost);
        }

        private void Awake()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            OnGoldChanged = null;
            OnSpeedChanged = null;
            OnPlayerUpgradeChanged = null;
            OnGameStateChanged = null;
            OnGameInitialized = null;
            OnGameStarted = null;
            OnGameEnded = null;
            OnGameWin = null;
        }
    }
}