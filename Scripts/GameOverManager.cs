using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public GameOverManager gameOverManager;
    private GameObject GO;

    void Awake(){
        GO = GameObject.FindGameObjectWithTag("Over");
    }
    void Start(){
        GO.SetActive(false);
    }



    private void OnEnable(){
        Player.OnPlayerDeath += Setup;
    }
    private void OnDisable(){
        Player.OnPlayerDeath -= Setup;
    }

    public void Setup(){
        GO.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Gameplay");
    }
    public void MenuButton(){
        SceneManager.LoadScene("Menu");
    }
}
