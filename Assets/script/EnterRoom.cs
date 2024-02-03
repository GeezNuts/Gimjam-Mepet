using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    public GameObject tallWall;
    public Animator anim;

    void Start()
    {
        tallWall.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag=="Player"){
            anim.SetBool("inRoom",true);
            tallWall.GetComponent<Collider2D>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"){
            anim.SetBool("inRoom",false);
            tallWall.GetComponent<Collider2D>().enabled = true;
        }
    }
}

