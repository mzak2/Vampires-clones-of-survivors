using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public void StartGameplay(string stageToPlay)
    {
        SceneManager.LoadScene("Essential", LoadSceneMode.Single);
        SceneManager.LoadScene(stageToPlay, LoadSceneMode.Additive);
        Time.timeScale = 1f; //starts game immediately incase player quit to main menu and then restarted, otherwise Time.timeScale=0 and unable to move
    }
}
