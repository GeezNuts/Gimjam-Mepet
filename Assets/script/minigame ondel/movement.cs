using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        speed= Random.Range(2,15);
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, 0); 
    }
}
