using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToggle : MonoBehaviour
{
   bool switchState=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void OnTriggerExit(Collider collision)
    {
        if (transform.GetChild(1).gameObject.activeSelf)
        {
            transform.parent.GetComponent<IfStatementCheck>().CheckIf(true);
        }
        else
        {

            transform.parent.GetComponent<IfStatementCheck>().CheckIf(false);
        }

        
    }
}
