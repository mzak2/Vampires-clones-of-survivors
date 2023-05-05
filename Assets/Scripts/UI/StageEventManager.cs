using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemiesManager enemiesManager;

    StageTime stageTime;
    int eventIndexer;
    PlayerWinManager playerWin;

    private void Awake()
    {
          stageTime= GetComponent<StageTime>();
    }

    private void Start()
    {
        playerWin = FindObjectOfType<PlayerWinManager>();
    }

    private void Update()
    {
        if (eventIndexer >= stageData.stageEvents.Count) { return; } //exit gate to avoid out of order

        if (stageTime.time > stageData.stageEvents[eventIndexer].time)
        {
            switch (stageData.stageEvents[eventIndexer].eventType)
            {
                case StageEventType.SpawnEnemy:                    
                    SpawnEnemy(false);
                    break;

                case StageEventType.SpawnObject:
                    SpawnObject();
                    break;

                case StageEventType.WinStage:
                    WinStage();
                    break;

                case StageEventType.SpawnEnemyBoss:
                    SpawnEnemyBoss();
                    break;
            }


            Debug.Log(stageData.stageEvents[eventIndexer].message);
            eventIndexer += 1;
        }
    }

    private void SpawnEnemyBoss()
    {
        SpawnEnemy(true);
    }

    private void WinStage()
    {
        playerWin.Win();
    }

    private void SpawnEnemy(bool bossEnemy)
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            enemiesManager.SpawnEnemy(stageData.stageEvents[eventIndexer].enemyToSpawn, bossEnemy);
        }
    }

    private void SpawnObject()
    {
        for (int i = 0; i < stageData.stageEvents[eventIndexer].count; i++)
        {
            Vector3 positionToSpawn = GameManager.instance.playerTransform.position;
            positionToSpawn += UtilityTools.GenerateRandomPositionSquarePattern(new Vector2(5f, 5f));

            SpawnManager.instance.SpawnObject(
                positionToSpawn,
                stageData.stageEvents[eventIndexer].objectToSpawn
                );
        }
    }
}

