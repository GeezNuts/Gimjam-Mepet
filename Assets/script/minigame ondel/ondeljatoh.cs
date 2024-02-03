using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ondeljatoh : MonoBehaviour
{
    
    private float timer;
    private float delay;
    public Rigidbody2D rb;
    public float clickPower;
    public float Falls;
    public penalty pen;
    public reward rew;
    private float PenaltyAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       
        jatoh();
        if(rb.rotation >= 90){
            rb.rotation  = 90;
            PlayerPrefs.SetInt("Ondel", 1);
            SceneManager.LoadScene(0);
        }
        if(rew.Reward){
            rb.rotation += clickPower;
            rew.Reward=false;
        }
    }
    void jatoh()
    {
        if(rb.rotation>0 && rb.rotation<90){  
            if(pen.Penalty){
                // Debug.Log("penalty");
                rb.rotation -= clickPower/2;
                pen.Penalty=false;
            }
            if (timer >= 0.01f)
            {
                timer = 0f;
                rb.rotation -= Falls;

            }
        }
    }
}
