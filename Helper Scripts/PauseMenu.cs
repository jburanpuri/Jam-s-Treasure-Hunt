using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused){
                resumeGame();
            }
            else{
                pauseGame();
            }
        }
    }

    public void resumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void pauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void loadMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }
}
