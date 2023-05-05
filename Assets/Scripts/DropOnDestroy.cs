using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] List<GameObject> dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance = 1f;



    bool isQuitting = false;

    private void Awake()
    {
        
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        if(isQuitting) { return; }

        if(dropItemPrefab.Count <= 0) 
        {
            Debug.Log("List of items to drop is empy");
            return;
        }

        if (Random.value < chance)
        {
            GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];

            if(toDrop == null ) 
            {
                Debug.Log("DropOnDestroy, reference to dropped item is null check the object  which drops items on destroy prefab");
                return;
            }

            SpawnManager.instance.SpawnObject(transform.position, toDrop);
        
            
        }
    }
}
