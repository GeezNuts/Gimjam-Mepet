using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 Origin;
    public bool target;
    public string find;
    public bool correct;
    void Start(){
        Origin = transform.position;
    }
    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        isDragging = false;
        if(!target){ 
           transform.position = Origin;
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, 1f); 
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    private void OnTriggerStay2D(Collider2D other)
     {
        // Debug.Log(other.tag);
        if (other.tag == find){
            target=true;
            correct=true;
            // Debug.Log("correct slot");
        }
        if(other.tag != "wire"){
            target=true;
            if(!isDragging){  
                transform.position = other.gameObject.transform.position;
            }
        }     
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "wire"){
           target=false;
           correct=false;
        }
    }
}