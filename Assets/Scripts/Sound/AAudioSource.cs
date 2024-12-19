using UnityEngine;

namespace MeowRescue.Sound
{
    public class AAudioSource : MonoBehaviour
    {
        protected AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }
    }
}