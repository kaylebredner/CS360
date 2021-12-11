using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("collision");
        if (this.tag == "VarContainer"&&other.gameObject.layer==6)
        {
          //  Debug.Log("varContainer");
            string varName;
            if (other.tag == "Variable")
            {
                varName = other.gameObject.transform.GetChild(0).name;
                transform.parent.parent.GetComponent<ModifyPlayer>().PassObject( varName,true);
            }
        }
        else if(this.tag == "ValContainer" && other.gameObject.layer == 6)
        {
            //Debug.Log("val");
            double val;
            if (other.tag == "dbl")
            {
                val  = int.Parse(other.gameObject.transform.GetChild(0).name);
                transform.parent.parent.GetComponent<ModifyPlayer>().PassObject( val,true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.tag == "VarContainer" && other.gameObject.layer == 6)
        {
            string varName;
            if (other.tag == "Variable")
            {
                varName = "";
                transform.parent.parent.GetComponent<ModifyPlayer>().PassObject(varName,false);
            }
        }
        else if (this.tag == "ValContainer" && other.gameObject.layer == 6)
        {
            double val;
            if (other.tag == "dbl")
            {
                val = 4;
                transform.parent.parent.GetComponent<ModifyPlayer>().PassObject(val,false);
            }
        }
    }
}
