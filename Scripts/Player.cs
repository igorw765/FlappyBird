using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public static event Action OnPlayerDeath;
    public Rigidbody2D rb;
    float jumpForce;
    bool jumpPressed;
    float yMovement;
    bool dead;
    bool paused;
    float time;

    //bool pauseButtonPressed;

    void Start()
    {
        jumpForce = 50f;
        rb.position = new Vector3(0, 0, 0);
        dead = false;
        //pauseButtonPressed = ControllsManager.instance.paused;
        PauseGame();
        SoundManager.PlaySound(SoundManager.Sound.swoosh);
        
    }



    void Update()
    {
        Renderer();

    }

    void Renderer(){

        CheckInput();

        if (jumpPressed)
        {
            StartPlaying();
            Move();
            //CheckPosition();
           
            rb.velocity = new Vector2(rb.position.x, yMovement);

        }
    }

    void StartPlaying()
    {
        if(paused && jumpPressed)
        {
            ResumeGame();
        }
    }

    void CheckInput()
    {

      //  #if UNITY_EDITOR

        // if(GameAssets.clicked)
        // {
        //     jumpPressed = Input.GetKeyDown("space");
        // }

       // #endif
        
        if(GameAssets.clicked)
        {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
                jumpPressed = true;
            }else{
                jumpPressed = false;
            }
            
        }

    }

    

    void Move()
    {
        yMovement = rb.velocity.y;
        yMovement += jumpForce;
        SoundManager.PlaySound(SoundManager.Sound.jump);

    }

    // void CheckPosition(){
    //     var lastPos = yMovement;
    //     if(yMovement > 0){
    //         rot.transform.Rotate(0,0,40f,0);
    //     }else if(yMovement < 0){
    //         rot.transform.Rotate(0,0,-40f,0);
    //     }else{
    //         rot.transform.Rotate(0,0,0,0);
    //     }
    // }

    void PauseGame ()
    {
        Time.timeScale = 0;
        paused = true;
    }

    void ResumeGame ()
    {
        if(!dead)
        {
        Time.timeScale = 1;
        paused = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            
        if (other.gameObject.tag == "pipe")
        {
            ScoreManager.instance.AddPoint();
            SoundManager.PlaySound(SoundManager.Sound.point);
        }
        else
        {
            SoundManager.PlaySound(SoundManager.Sound.die);
            dead = true;
            OnPlayerDeath?.Invoke();
            PauseGame();
        }
    }

}