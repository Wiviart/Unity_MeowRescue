using System;

namespace MeowRescue.Utilities
{
    public class Observer : Singleton<Observer>
    {
        public Action<int> OnGoldChanged;

        public void GoldChanged(int gold)
        {
            OnGoldChanged?.Invoke(gold);
        }

        public Action<float> OnSpeedChanged;
        public Action<StatsType> OnPlayerUpgradeChanged;

        public void PlayerUpgradeChanged(StatsType upgradeType)
        {
            OnPlayerUpgradeChanged?.Invoke(upgradeType);
        }

        public Action<GameState> OnGameStateChanged;

        public void GameStateChanged(GameState gameState)
        {
            OnGameStateChanged?.Invoke(gameState);
        }

        public Action OnGameInitialized;
        public Action OnGameStarted;
        public Action OnGameEnded;

        public void GameEnded()
        {
            OnGameEnded?.Invoke();
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
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}