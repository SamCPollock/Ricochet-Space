using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SoundEffectsManager : MonoBehaviour
{
    public static scr_SoundEffectsManager SFXManager;

    public AudioClip[] audioClips;
    public AudioClip music;

    private AudioSource audioSource;


    private void Awake()
    {
        SFXManager = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PlaySoundEffect(int clipIndex)
    {
        audioSource.PlayOneShot(audioClips[clipIndex]);
    }
}
