using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    BlackTransition bt;
    public void LoadNextLevel()         //by clicking Play button only
    {
        bt.FadeIn();
        Invoke("LoadNow", 1f);
    }
    private void LoadNow()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()          //by clicking Play button only
    {
        Invoke("ExitForSure", 4f);
    }
    private void ExitForSure()
    {
        Application.Quit();
    }
}
