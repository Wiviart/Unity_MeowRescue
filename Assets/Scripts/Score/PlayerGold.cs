using UnityEngine;

namespace Score
{
    public class PlayerGold
    {
        private int gold;
        public int Gold => gold;

        public PlayerGold()
        {
            gold = PlayerPrefs.GetInt(ConstTag.GOLD, 0);
        }

        public void AddGold(int value)
        {
            gold += value;

            PlayerPrefs.SetInt(ConstTag.GOLD, gold);
        }

        public void ResetGold()
        {
            gold = 0;
        }
    }
}