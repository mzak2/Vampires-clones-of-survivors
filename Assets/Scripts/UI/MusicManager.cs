using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip musicOnStart;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    AudioClip switchTo;

}
