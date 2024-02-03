using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskComplete : MonoBehaviour
{
    public Draggable connect;
    public Draggable connect1;
    public Draggable connect2;
    public Draggable connect3;
    public Animator anim;
    private float timer;
    void Start()
    {
        
    }
    void Update()
    {
        if(connect.correct && connect1.correct && connect2.correct && connect3.correct){
            timer += Time.deltaTime;
            anim.SetTrigger("Finish"); 
            if (timer >= 3){
                timer = 0f;
                PlayerPrefs.SetInt("Electric", 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
