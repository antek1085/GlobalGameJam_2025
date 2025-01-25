using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class OnBubblePop : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource audioSource;

    public void PlayOnDestroy()
    {
        particleSystem.Play();
            
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }
}
