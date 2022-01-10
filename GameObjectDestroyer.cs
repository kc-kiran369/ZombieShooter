using UnityEngine;
public class GameObjectDestroyer : MonoBehaviour
{
    [SerializeField] float time=1f;
    void Start()
    {
        Destroy(this.gameObject,time);
    }
}