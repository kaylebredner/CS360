using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypeChild : MonoBehaviour
{
    // Start is called before the first frame update
    int type=4;

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Debug.Log("Collison");
            //determines what datatype is in which box
            if (collision.gameObject.tag == "int")
            {
                type = 0;

            }
            else if (collision.gameObject.tag == "dbl")
            {
                type = 1;
            }
            else if (collision.gameObject.tag == "str")
            {
                type = 2;
            }
            else if (collision.gameObject.tag == "char")
            {
                type = 3;
            }
            else
            {

            }
            
            transform.parent.parent.GetComponent<DataTypeDetectionParent>().CollisionDetected(this, type);
        }
        
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 3)
        {
            transform.parent.parent.GetComponent<DataTypeDetectionParent>().CollisionExit(this);
        }
    }
    
        
    
}
