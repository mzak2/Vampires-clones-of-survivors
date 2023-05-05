using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : MonoBehaviour
{
    public AudioSource audioSource;

    public static EnemyDeathSound instance;

    protected virtual void Awake()
    {
        if( instance == null) 
        {
            instance = this;
        }
        else {
            Destroy(this);
            Debug.LogWarning("Multiple instances overlapping");
        }
    }        

    public void PlayDeathSound()
    {
        audioSource.Play();
    }
}
