using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    float lifeTime;
    float xMovement;

    void Start()
    {
        xMovement = 15f;
        lifeTime = 3.5f;
        rb.position = new Vector2(20f, rb.position.y);
    }

    void Update()
    {
        MoveGround();
        DestroyGround();
    }

    void MoveGround()
    {
        rb.velocity = new Vector2(-xMovement, rb.velocity.y);
    }

    void DestroyGround()
    {
        if(lifeTime > 0){
            lifeTime -= Time.deltaTime;
        }else{
            Destroy(this.gameObject);
        }
    }
}
