using System;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.parent == null && _audioSource.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }
}
