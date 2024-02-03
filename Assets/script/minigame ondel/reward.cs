using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reward : MonoBehaviour
{
    public bool Reward;
    public bool Clicked;
    public bool Hit;
    public penalty pen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            if(Hit){    
                Debug.Log("reward");
                Reward = true;
                Clicked= true;
            }
            else{
                Debug.Log("penalty");
                pen.Penalty=true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Hit = true;
        if(Clicked){
           Destroy(other.gameObject);
           Clicked=false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Hit = false;
    }
}
