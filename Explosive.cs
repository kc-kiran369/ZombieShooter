using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] ParticleSystemStorage ps;
    GameObject explosive;

    public void Explode()
    {
        explosive = ps.ReturnExplosive();
        Instantiate(explosive, transform.position, Quaternion.identity);
    }
}