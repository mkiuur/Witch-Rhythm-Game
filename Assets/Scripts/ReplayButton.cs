using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public GameObject resultsScreen;

    public void RestartGame(){
        if(resultsScreen.activeInHierarchy)
        {
            resultsScreen.SetActive(false);
            SceneManager.LoadScene("Start");
        }
    }
}
