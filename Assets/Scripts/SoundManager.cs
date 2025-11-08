using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    private const string AudioMixerMasterVolumeName = "MasterVolume";
    private const string AudioMixerMainVolumeName = "MainVolume";
    private const string AudioMixerMusicVolumeName = "MusicVolume";
    private const string AudioMixerEffectsVolumeName = "EffectsVolume";
    

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private MuteToggleButton _muteToggleButton;
    [SerializeField] private VolumeSlider _mainVolumeSlider;
    [SerializeField] private VolumeSlider _musicVolumeSlider;
    [SerializeField] private VolumeSlider _effectsVolumeSlider;

    private void Awake()
    {
        _muteToggleButton.Initialize(_audioMixer, AudioMixerMasterVolumeName);
        _mainVolumeSlider.Initialize(_audioMixer, AudioMixerMainVolumeName);
        _musicVolumeSlider.Initialize(_audioMixer, AudioMixerMusicVolumeName);
        _effectsVolumeSlider.Initialize(_audioMixer, AudioMixerEffectsVolumeName);
    }

    
}
