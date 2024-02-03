using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskCompleteBox : MonoBehaviour
{
    public DragAndDropBox connect;
    public DragAndDropBox connect1;
    public DragAndDropBox connect2;
    public DragAndDropBox connect3;
    public DragAndDropBox connect4;
    public DragAndDropBox connect5;
    void Start()
    {
        
    }
    void Update()
    {
        if(connect.correct && connect1.correct && connect2.correct && connect3.correct && connect4.correct && connect5.correct){
            PlayerPrefs.SetInt("Box",1);
            SceneManager.LoadScene(0);
        }
    }
}
