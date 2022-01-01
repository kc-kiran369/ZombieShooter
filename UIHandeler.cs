using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class UIHandeler : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] GameObject OptionsPanel;
    [SerializeField] RenderPipelineAsset[] qualitySettings;
    public Camera camera;
    private void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        OptionsPanel.SetActive(false);
    }
    private void Start()
    {
        camera = Camera.main;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))          //if esc is pressed toggle btwn pause menu
        {
            Resume();
        }
    }
    public void Resume()
    {
        if (pauseMenu.gameObject.activeSelf == true)
        {
            camera.GetComponent<AudioSource>().Play();
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
            GameState.currentGameState = GameState.CurrentGameState.Playing;
        }
        else
        {
            camera.GetComponent<AudioSource>().Pause();
            GameState.currentGameState = GameState.CurrentGameState.pauseMenu;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }

    }
    public void ToggleOptionsPanel()        //this func is called only when "options" button is clicked
    {
        OptionsPanel.SetActive(!OptionsPanel.activeSelf);
    }

    #region Options
    public void ChangeSensitivity(Slider s)     //this is called from options slider
    {
        MouseLook.MouseSensitivity = s.value * 100;
    }
    public void ChangeResolution(TMP_Dropdown tmp)
    {
        switch (tmp.value)
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
                Screen.SetResolution(800, 600, true);
                break;
        }
    }
    public void ChangeGraphics(TMP_Dropdown tmp)
    {
        switch (tmp.value)
        {
            case 0:
                QualitySettings.SetQualityLevel(0);
                QualitySettings.renderPipeline = qualitySettings[0];

                break;
            case 1:
                QualitySettings.SetQualityLevel(1);
                QualitySettings.renderPipeline = qualitySettings[1];
                break;
            case 2:
                QualitySettings.SetQualityLevel(2);
                QualitySettings.renderPipeline = qualitySettings[2];
                break;
        }
    }
    #endregion
    public void QuitToDesktop()
    {

        Application.Quit();
    }

}