using UnityEngine;

public class BlackTransition : MonoBehaviour
{
    [SerializeField] Animator Fade;
    public void FadeIn()
    {
        Fade.SetTrigger("FadeIn");
    }
    public void FadeOut()
    {
        Fade.SetTrigger("FadeOut");
    }
}