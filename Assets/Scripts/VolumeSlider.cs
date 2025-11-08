using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private const float MinSliderValue = 0.0001f;
    private const float MaxSliderValue = 1f;
    private const float DecibelMultiplier = 20f;

    private Slider _slider;
    private AudioMixer _audioMixer;
    private string _parameterVolume;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = MinSliderValue;
        _slider.maxValue = MaxSliderValue;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(value => SetVolume(value));
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(value => SetVolume(value));
    }

    public void Initialize(AudioMixer audioMixer, string parameterName)
    {
        _audioMixer = audioMixer;
        _parameterVolume = parameterName;
    }

    public void SetVolume(float value)
    {
        if (_audioMixer == null || _audioMixer == null)
            return;

        _audioMixer.SetFloat(_parameterVolume, Mathf.Log10(value) * DecibelMultiplier);
    }
}