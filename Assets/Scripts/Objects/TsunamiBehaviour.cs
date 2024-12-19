using MeowRescue.Data;
using UnityEngine;

namespace MeowRescue.Objects
{
    public class TsunamiBehaviour : MonoBehaviour
    {
        private readonly float[] speeds = { 10f, 40f };
        private int index = 0;

        private void Update()
        {
            bool isPlaying = LevelManager.GameState == GameState.Playing;
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