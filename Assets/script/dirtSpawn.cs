using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class spawner : MonoBehaviour
{
    public int numberDirt=0;
    private int winCondition;
    public int counterDirt=0;
    public float maxHeight;
    public float minHeight;
    public float maxWidth;
    public float minWitdh;
    private float timer = 0f;

     [SerializeField] public GameObject Dirt;
    GameObject spawningDirt;
   
    void SpawnDirt()
    {
        Vector3 randomizePosition = new Vector3( Random.Range(maxWidth, minWitdh), Random.Range(maxHeight, minHeight), 0);
        Quaternion randomizeRotation = Quaternion.Euler(0, Random.Range(0, 0), 0);
        spawningDirt = Instantiate(Dirt, randomizePosition, randomizeRotation);
    }
    void Start()
    {
        winCondition=numberDirt;
         while(numberDirt > 0){
            SpawnDirt();
            numberDirt--;
         }
    }

    void Update()
    {
        followMouse();
        if(counterDirt >= winCondition){
            taskComplete();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("dirt"))
        {
            counterDirt++;
            Destroy(other.gameObject);
        }
    }
    void followMouse(){
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = mousePos;
    }
    void taskComplete(){
        timer += Time.deltaTime;
         if (timer >= 3)
         {
            timer = 0f;
            PlayerPrefs.SetInt("Mirror", 1);
            SceneManager.LoadScene(0);
         }
    }
}