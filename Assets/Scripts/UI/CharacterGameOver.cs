using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{

    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;
    [SerializeField] PauseManager pauseManager;
    

    public void GameOver()
    {
        Debug.Log("Game Over");
        GetComponent<PlayerMove>().enabled = false; //disables player movement script so player doesnt move after death
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
        pauseManager.PauseGame();

    }
}
