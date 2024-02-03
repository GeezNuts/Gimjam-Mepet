using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penalty : MonoBehaviour
{
    public bool Penalty;
    public Rigidbody2D balls;
    Vector3 spawnLoc;
    public float timer;
    public float delay;
    void Start()
    {
        spawnLoc = new Vector3(balls.position.x , 3.3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        spawnBalls();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Penalty=true;
    }
    void spawnBalls(){
        Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
        timer += Time.deltaTime;
         if (timer >= delay)
         {
            timer=0f;
            Instantiate(balls,spawnLoc, randomizeRotation);
         }
    }
}
