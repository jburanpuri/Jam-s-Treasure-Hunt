using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finalMenu : MonoBehaviour
{
    public void replay(){
        SceneManager.LoadScene("SampleScene");
    }

    public void menu(){
        SceneManager.LoadScene("MainMenu");
    }
}
