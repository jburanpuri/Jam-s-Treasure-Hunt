using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void loadHelp(){
        SceneManager.LoadScene("Help");
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }
}
