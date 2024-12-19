using MeowRescue.Data;
using MeowRescue.Utilities;

namespace MeowRescue.Score
{
    public class PlayerGold
    {
        private int gold;
        public int Gold => gold;
        
        public PlayerGold()
        {
            Loader.Load(ConstTag.GOLD, out int g);
            AddGold(g);
        }

        public void AddGold(int value)
        {
            gold += value;
            Saver.Save(ConstTag.GOLD, gold);
            Observer.Instance.GoldChanged(gold);
        }
    }
}