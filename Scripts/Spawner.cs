using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipe;
    public GameObject ground;
    public Transform rotation;
    public Transform spawner;
    float timep;
    float timeg;

    void Start()
    {
        timep = 2f;
        timeg = 1f;
    }

    void Update()
    {
        InitiatePipe();
        InitiateGround();
    }

    void InitiatePipe()
    {
        timep -= Time.deltaTime;

        if(timep <= 0){
            Instantiate(pipe, spawner.position, rotation.rotation);
            timep = 2f;
        }
    }

    void InitiateGround()
    {
        timeg -= Time.deltaTime;

        if(timeg <= 0)
        {
            Instantiate(ground, new Vector3(42f, -25f, 0), Quaternion.identity);
            timeg = 2f;
        }
    }
}
