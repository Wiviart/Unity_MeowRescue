using MeowRescue.Utilities;

namespace MeowRescue.Sound
{
    public class SFX_Handler : AAudioSource
    {
        public AudioData data;

        private void OnEnable()
        {
            Observer.Instance.OnGameEnded += () => PlayVFX(2);
            Observer.Instance.OnGameWin += () => PlayVFX(1);
            Observer.Instance.OnMeowCatched += () => PlayVFX(0);
            Observer.Instance.OnPlayerUpgrade += (type) => PlayVFX(3);
        }
        
        private void PlayVFX(int index)
        {
            source.clip = index switch
            {
                0 => data.pickupClip,
                1 => data.winClip,
                2 => data.loseClip,
                3 => data.buttonClickClip,
                _ => null
            };
            source.Play();
        }
    }
}