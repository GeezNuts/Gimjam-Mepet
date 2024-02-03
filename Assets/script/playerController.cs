using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    public bool Epressed=false;
    [SerializeField] float speed = 5f;
    private float speedup = 5f;
    public Rigidbody2D rb;
    public GameObject light;
    public AudioSource audioSource;
    public Animator anim;
    private bool facingRight;

    void Start()
    {
        if(PlayerPrefs.GetInt("Task") > 0){
           transform.position=new Vector2(PlayerPrefs.GetFloat("posX"),PlayerPrefs.GetFloat("posY"));
        }
        if(PlayerPrefs.GetInt("Electric") > 0){  
            light.SetActive(true);
        }
    }

    void Update()
    {
        Epressed=false;
        
        PlayerMovement();
        if(Input.GetKeyDown(KeyCode.E)){
            Epressed=true;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            PlayerPrefs.DeleteAll();
            Debug.Log("Player Pref Reset");
        }
        if(Input.GetKeyDown(KeyCode.F)){
            PlayerPrefs.SetInt("Electric", 1);
            PlayerPrefs.SetInt("Mirror", 1);
            PlayerPrefs.SetInt("Box",1);
            Debug.Log("Allquest complete"); 
        }
        if(PlayerPrefs.GetInt("Pocong") > 0){
            anim.SetTrigger("isPocong");
            PlayerPrefs.SetInt("Pocong",0);
        }
    }
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        audiowalk(horizontalInput,verticalInput);
        moveanimcontroller(horizontalInput,verticalInput);
        if(horizontalInput < 0 && !facingRight)
            Flip();
        else if(horizontalInput > 0 && facingRight)
            Flip();
        if( verticalInput!=0  && horizontalInput !=0)
        {
            speedup = speed / 2;
        }
        else
        {
            speedup = speed - (speed / 4);
        }
        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speedup);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerPrefs.SetInt("Task",1);
        PlayerPrefs.SetFloat("posX",transform.position.x);
        PlayerPrefs.SetFloat("posY",transform.position.y);
        if (other.gameObject.CompareTag("Mirror") && Epressed && PlayerPrefs.GetInt("Mirror") == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (other.gameObject.CompareTag("Electric") && Epressed && PlayerPrefs.GetInt("Electric") == 0)
        {
            SceneManager.LoadScene(2);
        }       
        if (other.gameObject.CompareTag("Ondel") && Epressed && PlayerPrefs.GetInt("Ondel") == 0)
        {
            SceneManager.LoadScene(3);
        }  
        if (other.gameObject.CompareTag("Box") && Epressed && PlayerPrefs.GetInt("Box") == 0)
        {
            SceneManager.LoadScene(4);
        }   
    }
    void audiowalk(float horizontalInput, float verticalInput){
        if(verticalInput!=0 || horizontalInput !=0 ){
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    void moveanimcontroller(float horizontalInput, float verticalInput){
        if(horizontalInput == 0 || verticalInput == 0 ){
            anim.SetBool("WalkingRight",false);
            anim.SetBool("WalkingUp",false);
        }
        if(horizontalInput != 0 || verticalInput < 0 ){
            anim.SetBool("WalkingRight",true);
            anim.SetBool("WalkingUp",false);
        }
        else if(verticalInput > 0 && horizontalInput == 0){
            anim.SetBool("WalkingUp",true);
            anim.SetBool("WalkingRight",false);
        }
    }
    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
