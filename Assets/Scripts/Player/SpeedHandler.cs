using MeowRescue.Data;
using MeowRescue.Score;
using MeowRescue.Utilities;
using UnityEngine;

namespace MeowRescue.Player
{
    public class SpeedHandler
    {
        private readonly PlayerGold playerGold;
        private int cost = ConstTag.speedUpgradeBeginCost;
        public float Speed { private set; get; } = ConstTag.startSpeed;

        public SpeedHandler(PlayerGold playerGold)
        {
            this.playerGold = playerGold;

            Loader.Load(ConstTag.SPEED, out float speed);
            Speed = Mathf.Max(speed, Speed);
            Loader.Load(ConstTag.SPEED_COST, out int c);
            cost = Mathf.Max(c, cost);

            Observer.Instance.SpeedChanged(Speed, cost);
        }

        public void UpdateSpeed()
        {
#if UNITY_EDITOR
#else
        if (playerGold.Gold < cost) return;
#endif

            Speed += ConstTag.speedMultiplier;
            // int pow = (int)((Speed - ConstTag.startSpeed) / ConstTag.speedMultiplier);
            // cost = ConstTag.speedUpgradeBeginCost + (int)Mathf.Pow(2, pow);
            cost += ConstTag.speedUpgradeCostMultiplier;
            playerGold.AddGold(-cost);

            Saver.Save(ConstTag.SPEED, Speed);
            Saver.Save(ConstTag.SPEED_COST, cost);
            Observer.Instance.SpeedChanged(Speed, cost);
        }

        public void ResetSpeed()
        {
            Speed = ConstTag.startSpeed;
            cost = ConstTag.speedUpgradeBeginCost;
            Saver.Save(ConstTag.SPEED, Speed);
            Saver.Save(ConstTag.SPEED_COST, cost);
            Observer.Instance.SpeedChanged(Speed, cost);
        }
    }
}