using MeowRescue.Data;
using UnityEngine;

namespace MeowRescue.Meow
{
    public class MeowBehaviour : MonoBehaviour
    {
        private int speed;

        private void Start()
        {
            Loader.Load(ConstTag.LEVEL, out speed);
        }
    }
}