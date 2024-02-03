using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public GameObject Box;
    public GameObject BoxOutline;
    public Sprite BoxAfter;
    public GameObject Electric;
    public GameObject ElectricOutline;
    public Sprite ElectricAfter;
    public GameObject Mirror;
    public GameObject MirrorOutline;
    public Sprite MirrorAfter;
    public GameObject Light;
    public GameObject Lift;
    public Sprite LiftAfter;

    void Start()
    {
        if(PlayerPrefs.GetInt("Electric") == 0){
            Light.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Box") > 0){
            Box.GetComponent<SpriteRenderer>().sprite = BoxAfter;
            BoxOutline.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Electric") > 0){
            Light.SetActive(true); 
            Electric.GetComponent<SpriteRenderer>().sprite = ElectricAfter;
            ElectricOutline.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Mirror") > 0){
            Mirror.GetComponent<SpriteRenderer>().sprite = MirrorAfter;
            MirrorOutline.SetActive(false);
        }
        if(PlayerPrefs.GetInt("Mirror") > 0 && PlayerPrefs.GetInt("Electric") > 0 && PlayerPrefs.GetInt("Box") > 0){
            Lift.GetComponent<SpriteRenderer>().sprite = LiftAfter;
            Lift.GetComponent<BoxCollider2D>().enabled=false;
            Lift.GetComponent<PolygonCollider2D>().enabled=false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerPrefs.SetInt("Pocong",1);
        }
    }
}
