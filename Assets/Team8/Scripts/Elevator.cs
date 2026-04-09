using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] bool movingUp = false;
    
    // Update is called once per frame
    void Update()
    {
         if (movingUp)
        {
            float moveAmount = moveSpeed * Time.deltaTime;
            transform.Translate(0, moveAmount, 0);
        }
    }

     void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            movingUp = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            movingUp = false;
        }
    }

}
