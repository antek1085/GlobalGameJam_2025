using UnityEngine;

public class MusicMaster : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    public void MuteMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ChangeVolume(float value)
    {
        value = Mathf.Clamp(value, 0f, 1f);
        musicSource.volume = value;
    }
}
