using UnityEngine;

[CreateAssetMenu]
public class ParticleSystemStorage : ScriptableObject
{
    [SerializeField]GameObject m_SandHitEffect;
    [SerializeField]GameObject m_BloodHitEffect;
    [SerializeField]GameObject m_BigExplosive;
    public GameObject ReturnSandEffect()
    {
        return m_SandHitEffect;
    }
    public GameObject ReturnBloodEffect()
    {
        return m_BloodHitEffect;
    }
    public GameObject ReturnExplosive()
    {
        return m_BigExplosive;
    }
}
