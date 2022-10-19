using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllsManager : MonoBehaviour
{

    public static ControllsManager instance;
    public bool paused = false;


    public void TimeOperations(){
        if(!paused){
            PauseGame();
        }else if(paused){
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
    }

}
