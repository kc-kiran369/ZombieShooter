using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider _master;
    [SerializeField] Slider _music;
    [SerializeField] Slider _sfx;
    [SerializeField] AudioMixer mixer;

    private void Awake()
    {
        _master.value = 0;
        _music.value = 0;
        _sfx.value = 0;
    }

    public void ChangeMasterVolume()            //changed from options panel
    {
        mixer.SetFloat("MasterVolume", _master.value);
    }
    public void ChangeMusicVolume()            //changed from options panel
    {
        mixer.SetFloat("MusicVolume", _music.value);
    }
    public void ChangeSfxVolume()            //changed from options panel
    {
        mixer.SetFloat("SFXVolume", _sfx.value);
    }
}
