using UnityEngine;

public class UIHandeler : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] GameObject OptionsPanel;
  
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
        Cursor.lockState = CursorLockMode.Locked;

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
    public void QuitToDesktop()
    {

        Application.Quit();
    }

}