using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandeler : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] GameObject OptionsPanel;
    private void Awake()
    {
        pauseMenu.gameObject.SetActive(false);
        OptionsPanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Resume();
        }
    }
    public void Resume()
    {
        if (pauseMenu.gameObject.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
            GameState.currentGameState = GameState.CurrentGameState.Playing;
        }
        else
        {
            GameState.currentGameState = GameState.CurrentGameState.pauseMenu;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }

    }
    public void ToggleOptionsPanel()
    {
        OptionsPanel.SetActive(!OptionsPanel.activeSelf);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
        //SceneManager.UnloadScene(1);
    }
}