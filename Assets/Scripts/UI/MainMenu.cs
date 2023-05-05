using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    // Start is called before the first frame update
    private void Awake()
    {
        pauseManager= GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(panel.activeInHierarchy == false) //will only attempt to open main menu when it is not open and close it if opened and pressing escape again
            {
                OpenMenu();
            }
            else {
                CloseMenu();
            }
        }
    }

    public void CloseMenu()
    {
        pauseManager.UnPauseGame();
        panel.SetActive(false); 
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }
}
