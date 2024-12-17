using UnityEngine;

namespace Score
{
    public class PlayerScore
    {
        private int score;

        public int Score => score;

        public void AddScore(int value)
        {
            score += value;
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}