using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;

    [SerializeField] GameWinPanel levelCompletePanel;
    private void Awake()
    {
        stageTime= GetComponent<StageTime>();
        pauseManager= FindObjectOfType<PauseManager>();
        levelCompletePanel = FindObjectOfType<GameWinPanel>(true);
    }

    public void Update()
    {
        if(stageTime.time > timeToCompleteLevel) //when time in game is over timeToCompleteLevel, then game is complete
        {
            pauseManager.PauseGame();
            levelCompletePanel.gameObject.SetActive(true);
        }
    }
}
