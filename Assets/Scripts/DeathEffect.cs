using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticles;
    public void PlayDeathEffect()
    {
        deathParticles.Play();
    }
}
