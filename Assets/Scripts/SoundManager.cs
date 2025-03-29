using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    Sowrd,
    fire,
    punch,
    FootSteps

}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{   [SerializeField] private AudioClip[] soundList; 
    private static SoundManager instance;
    private AudioSource audioSource;
    void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound(SoundType sound , float volume = 1f)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound],volume);
    }
}
