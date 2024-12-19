using MeowRescue.Data;
using MeowRescue.Utilities;
using UnityEngine;

namespace MeowRescue.Objects
{
    public class TsunamiBehaviour : MonoBehaviour
    {
        private readonly float[] speeds = { 10f, 40f };
        private int index = 0;
        private bool isPlaying;
        
        private void OnEnable()
        {
            Observer.Instance.OnGameStart += () => isPlaying = true;
            Observer.Instance.OnGameEnded += () => isPlaying = false;
            Observer.Instance.OnGameWin += () => isPlaying = false;
        }

        private void Update()
        {
            if (!isPlaying) return;
            transform.position += Vector3.forward * speeds[index] * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(ConstTag.CHECKPOINT)) return;
            if (index >= speeds.Length - 1) return;
            index++;
        }
    }
}