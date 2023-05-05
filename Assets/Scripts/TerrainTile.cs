using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    [SerializeField] List<SpawnObject> spawnObjects;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition); //adds this gameobject at position, creating a new method in Worldscrolling to be called
    }

    public void Spawn()
    {
        for(int i = 0; i < spawnObjects.Count; i++) 
        {
            spawnObjects[i].Spawn();
        }
    }

}
