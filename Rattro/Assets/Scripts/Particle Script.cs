using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem particleEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //checks if player has player tah
            if (particleEffect != null)
            {
                particleEffect.Play();
            }
        }
    }
