using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private int temp;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(temp);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag!="rooms"){
            temp = player.GetComponent<Renderer>().sortingOrder;
            Debug.Log(temp);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag!="rooms" && other.GetComponent<Renderer>().sortingOrder > player.GetComponent<Renderer>().sortingOrder - 1)
        {
            player.GetComponent<Renderer>().sortingOrder = other.GetComponent<Renderer>().sortingOrder + 1;
        } 
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.tag!="rooms"){
            player.GetComponent<Renderer>().sortingOrder = 0;
        }
    }
}
