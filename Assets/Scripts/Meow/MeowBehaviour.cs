using UnityEngine;

namespace MeowRescue.Meow
{
    public class MeowBehaviour : MonoBehaviour
    {
        private int speed;

        private void Start()
        {
            speed = PlayerPrefs.GetInt(ConstTag.LEVEL, 0);
        }
    }
}