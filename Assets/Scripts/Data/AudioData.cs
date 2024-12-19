using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    public AudioClip pickupClip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip buttonClickClip;
}