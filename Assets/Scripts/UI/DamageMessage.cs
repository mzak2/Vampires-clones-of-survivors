using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float TimeToLive = 2f;
    float ttl = 2f;

    private void OnEnable()
    {
        ttl = TimeToLive;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0f)
        {
            gameObject.SetActive(false); //avoids having to reinstantiate instead of Destroy(gameobject)
        }
    }
}
