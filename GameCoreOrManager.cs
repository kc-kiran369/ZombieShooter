using UnityEngine;

public class GameCoreOrManager : MonoBehaviour
{
    [SerializeField]
    Animator black;
    private void Awake()
    {
        Screen.SetResolution(1280, 720, true);
        //black.SetTrigger("FadeOut");
    }
}   
