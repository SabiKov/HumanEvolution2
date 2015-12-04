using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MushroomSoundController : MonoBehaviour {


    public AudioClip impact;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!audio.isPlaying)
                audio.Stop();
                audio.PlayOneShot(impact);
        }

    }
}

