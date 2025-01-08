using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public const string MasterVolume = "MasterVolume";
    public const string MusicVolume = "MusicVolume";
    public const string SoundVolume = "SoundVolume";
    public const float MinVolume = 0.001f;
    public const int FormulaMultiplier = 20;

    [SerializeField] private AudioMixerGroup _audioMixer;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Toggle _audioToggle;

    [SerializeField] private float _masterVolume;

    private void Awake()
    {
        _audioToggle.onValueChanged.AddListener(ToggleAudio);
        _masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        _soundVolumeSlider.onValueChanged.AddListener(SetSoundVolume);
        _musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMasterVolume(float value)
    {
        _masterVolume = value;
        _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(value) * FormulaMultiplier);
    }

    public void SetSoundVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat(SoundVolume, Mathf.Log10(value) * FormulaMultiplier);
    }

    public void SetMusicVolume(float value)
    {
        _audioMixer.audioMixer.SetFloat(MusicVolume, Mathf.Log10(value) * FormulaMultiplier);
    }

    public void ToggleAudio(bool value)
    {
        if (value)
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(_masterVolume) * FormulaMultiplier);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(MinVolume) * FormulaMultiplier);
        }
    }
}
