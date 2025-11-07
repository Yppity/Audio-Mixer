using UnityEngine;
using UnityEngine.Audio;

public class Soundbar : MonoBehaviour
{
    private const float DecibelMultiplier = 20f;
    private const float MuteVolume = -80f;
    private const float UnmuteVolume = 0f;

    [SerializeField] private AudioMixer _audioMixer;
    private bool _isMute = false;

    public void ToggleMute()
    {
        _isMute = !_isMute;

        _audioMixer.SetFloat("MasterVolume", _isMute ? MuteVolume : UnmuteVolume);
    }

    public void SetMainVolume(float volume)
    {
        _audioMixer.SetFloat("MainVolume", Mathf.Log10(volume) * DecibelMultiplier);
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * DecibelMultiplier);
    }

    public void SetEffectsVolume(float volume)
    {
        _audioMixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * DecibelMultiplier);
    }
}
