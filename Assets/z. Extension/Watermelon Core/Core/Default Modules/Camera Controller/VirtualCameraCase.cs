using Unity.Cinemachine;
using UnityEngine;

namespace Watermelon
{
    [System.Serializable]
    public sealed partial class VirtualCameraCase
    {
        [SerializeField] CameraType cameraType;
        public CameraType CameraType => cameraType;

        [SerializeField] CinemachineCamera virtualCamera;
        public CinemachineCamera VirtualCamera => virtualCamera;

        private TweenCase shakeTweenCase;

        public void Initialise()
        {
        }

        public void Shake(float fadeInTime, float fadeOutTime, float duration, float gain)
        {
            if (shakeTweenCase != null && !shakeTweenCase.isCompleted)
                shakeTweenCase.Kill();

            var cinePerlin =
                virtualCamera.GetCinemachineComponent(CinemachineCore.Stage
                    .Noise) as CinemachineBasicMultiChannelPerlin;

            shakeTweenCase = Tween
                .DoFloat(0.0f, gain, fadeInTime, (float fadeInValue) => { cinePerlin.AmplitudeGain = fadeInValue; })
                .OnComplete(delegate
                {
                    shakeTweenCase = Tween.DelayedCall(duration,
                        delegate
                        {
                            shakeTweenCase = Tween.DoFloat(gain, 0.0f, fadeOutTime,
                                (float fadeOutValue) => { cinePerlin.AmplitudeGain = fadeOutValue; });
                        });
                });
        }
    }
}