using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public GameObject pipe;
    public Rigidbody2D rb;
    float lifeTime;
    float xMovement;
    float hight;



    void Start()
    {
        xMovement = 10f;
        lifeTime = 7f;
        hight = Random.Range(-17.0f, 17.0f);
    }

    void Update()
    {
        MovePipe();
        DestroyPipe();
        
    }

    void MovePipe()
    {
        rb.velocity = new Vector2(-xMovement, rb.velocity.y);
        rb.position = new Vector2(rb.position.x, hight);
    }

    void DestroyPipe()
    {
        if(lifeTime > 0){
            lifeTime -= Time.deltaTime;
        }else{
            Destroy(this.gameObject);
        }
    }
}
