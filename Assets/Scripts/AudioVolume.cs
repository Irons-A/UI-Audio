using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public const string MasterVolume = "MasterVolume";
    public const string MusicVolume = "MusicVolume";
    public const string SoundVolume = "SoundVolume";

    [SerializeField] private AudioMixerGroup _audioMixer;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Toggle _soundToggle;

    [SerializeField] private float _masterVolume;
    [SerializeField] private float _soundVolume;
    [SerializeField] private float _musicVolume;
    [SerializeField] private bool _isSoundEnabled = true;

    private float _minVolume = 0.0001f;

    private void Awake()
    {
        _soundToggle.onValueChanged.AddListener(ToggleSound);
    }

    public void SetMasterVolume()
    {
        _masterVolume = _masterVolumeSlider.value;
        _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(_masterVolume)*20);
    }

    public void SetSoundVolume()
    {
        _soundVolume = _soundVolumeSlider.value;
        _audioMixer.audioMixer.SetFloat(SoundVolume, Mathf.Log10(_soundVolume) * 20);
    }

    public void SetMusicVolume()
    {
        _musicVolume = _musicVolumeSlider.value;
        _audioMixer.audioMixer.SetFloat(MusicVolume, Mathf.Log10(_musicVolume) * 20);
    }

    public void ToggleSound(bool value)
    {
        if (value)
        {
            _audioMixer.audioMixer.SetFloat(SoundVolume, Mathf.Log10(_soundVolume) * 20);
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(SoundVolume, Mathf.Log10(_minVolume) * 20);
        }
    }
}
