using System;
using UnityEngine;
using UnityEngine.Audio;

namespace MeowRescue.Sound
{
    public class Audio_Handler : MonoBehaviour
    {
        public AudioMixer mixer;

        private const string MASTER = "Master";
        private const string MUSIC = "BGM";
        private const string SFX = "SFX";

        private void SetFloat(string name, float value)
        {
            mixer.SetFloat(name, Mathf.Log10(value) * 20);
        }
    }
}