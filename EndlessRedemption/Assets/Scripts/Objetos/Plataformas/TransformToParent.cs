using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToParent : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

       
            if (collision.gameObject.GetComponent<MovementComponent>())
            {
                collision.gameObject.transform.parent = gameObject.transform;
                Debug.Log("pegao");
            }

        


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
            if (collision.gameObject.GetComponent<MovementComponent>())
            {
                collision.transform.parent = null;
                Debug.Log("fuera");
            }

        

    }
    // Start is called before the first frame update
 
}
