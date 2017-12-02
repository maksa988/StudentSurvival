using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    [SerializeField]
    private bool playTriggered = false;
    [SerializeField]
    private bool stopTriggered = false;

    private AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(this.playTriggered)
        {
            this.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (this.stopTriggered)
        {
            this.Stop();
        }
    }

    public void Play()
    {
        if(!this.audioSource.isPlaying)
        {
            this.audioSource.Play();
        }
    }

    public void Stop()
    {
        if(this.audioSource.isPlaying)
        {
            this.audioSource.Stop();
        }
    }
}
