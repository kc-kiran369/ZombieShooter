using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] Transform Player;
    NavMeshAgent zombieNav;
    readonly static float Range = 20f;
    float distanceToTarget;
    void Start()
    {
        zombieNav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (GameState.currentGameState == GameState.CurrentGameState.Playing)
        {
            distanceToTarget = Vector3.Distance(transform.position, Player.transform.position);
            if (distanceToTarget <= Range)
            {

                zombieNav.SetDestination(Player.position);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
