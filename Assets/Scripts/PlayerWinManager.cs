using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winMessagePanel;
    PauseManager pauseManager;
    [SerializeField] DataContainer dataContainer;

    public void Start()
    {
        pauseManager= GetComponent<PauseManager>();
    }

    public void Win()
    {
        winMessagePanel.SetActive(true);
        pauseManager.PauseGame();
        dataContainer.StageComplete(0);
    }
}
