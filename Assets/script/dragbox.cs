using UnityEngine;

public class DragAndDropBox : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    public bool correct;
    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        isDragging = false;
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
        if(other.tag == "Target"){
            correct=true;
        }     
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Target"){
            correct=false;
        }     
    }
}