using MeowRescue.Data;
using UnityEngine;

namespace Score
{
    public class PlayerGold
    {
        private int gold;
        public int Gold => gold;

        public PlayerGold()
        {
            Loader.Load(ConstTag.GOLD, out gold);
        }

        public void AddGold(int value)
        {
            gold += value;
            Saver.Save(ConstTag.GOLD, gold);
        }

        public void ResetGold()
        {
            gold = 0;
        }
    }
}