using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageEventType
{
    SpawnEnemy,
    SpawnEnemyBoss,
    SpawnObject,
    WinStage
}

[Serializable] //allows stage event to be editable in  editor
public class StageEvent
{
    public StageEventType eventType;

    public float time;
    public string message;

    public EnemyData enemyToSpawn;
    public GameObject objectToSpawn;
    public int count;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
   public List<StageEvent> stageEvents;
}
