using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public void Play()
    {
        AudioSource aso = GetComponent<AudioSource>();

        if(!aso.isPlaying)
        {
            aso.Play();
        }
    }
}
