using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class SettingsManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _resolution;
    [SerializeField] TMP_Dropdown _quality;
    [SerializeField] Slider _sensitivity;

    [SerializeField] Slider _masterAudio;
    [SerializeField] Slider _soundAudio;
    [SerializeField] Slider _sfxAudio;

    [SerializeField] RenderPipelineAsset[] qualitySettings;

    void Awake()
    {
        _sensitivity.value = (MouseLook.MouseSensitivity) / 100;
        _resolution.value = 2;
        _quality.value = 1;
        ChangeResolution();
        ChangeGraphics();
    }
    public void ChangeSensitivity(Slider s)     //this is called from options slider
    {
        MouseLook.MouseSensitivity = s.value * 100;
    }

    public void ChangeResolution()       //this is called from pause menu
    {
        int temp = _resolution.value;
        switch (temp)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 1:
                Screen.SetResolution(1366, 768, true);
                break;
            case 2:
                Screen.SetResolution(1280, 720, true);
                break;
            case 3:
                Screen.SetResolution(1024, 576, true);
                break;
            case 4:
                Screen.SetResolution(960, 540, true);
                break;
        }
    }
    public void ChangeGraphics()                //this is called from pause menu
    {
        int temp = _quality.value;
        QualitySettings.SetQualityLevel(temp);
        QualitySettings.renderPipeline = qualitySettings[temp];
    }
}
