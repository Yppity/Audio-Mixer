using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteToggleButton : MonoBehaviour
{
    private const float MuteVolume = -80f;
    private const float UnmuteVolume = 0f;

    private Button _button;
    private AudioMixer _audioMixer;
    private string _parameterVolume;
    private bool _isMute = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMute);
    }

    public void Initialize(AudioMixer audioMixer, string parameterName)
    {
        _audioMixer = audioMixer;
        _parameterVolume = parameterName;
    }

    public void ToggleMute()
    {
        if (_audioMixer == null || _parameterVolume == null)
            return;

        _isMute = !_isMute;

        _audioMixer.SetFloat(_parameterVolume, _isMute ? MuteVolume : UnmuteVolume);
    }
}
