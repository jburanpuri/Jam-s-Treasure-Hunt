using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helpMenu : MonoBehaviour
{

    // Update is called once per frame
    public void back(){
        SceneManager.LoadScene("MainMenu");
    }
}
