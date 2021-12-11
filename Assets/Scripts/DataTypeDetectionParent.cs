using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTypeDetectionParent : MonoBehaviour
{   bool integer=false;
    bool dbl = false;
    bool str = false;
    bool character = false;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);  
    }

    // Update is called once per frame
    public void CollisionDetected(DataTypeChild dataChild, int type)
    {
        //checks each box for correct datatype and opens door if all are correct
        if (dataChild.gameObject.name == "IntBottom" && type == 0)
        {
            integer = true;
            Debug.Log("int");
        }
        else if (dataChild.gameObject.name == "DblBottom" && type == 1)
        {
            dbl = true;
            Debug.Log("dbl");
        }
        else if (dataChild.gameObject.name == "StrBottom" && type == 2)
        {
            str = true;
            Debug.Log("str");
        }
        else if (dataChild.gameObject.name == "CharBottom" && type == 3)
        {
            character = true;
            Debug.Log("char");
        }
        else
        {
            //Debug.Log("incorrect detection");
        }
        if (integer && dbl && str && character)
        {
            door.SetActive(false);
        }
    }
    public void CollisionExit(DataTypeChild dataChild)
    {
        //sets booleans to false if an object is removed from its box
        if (dataChild.gameObject.name == "IntBottom" )
        {
            integer = false;
        }
        else if (dataChild.gameObject.name == "DblBottom" )
        {
            dbl = false;
        }
        else if (dataChild.gameObject.name == "StrBottom" )
        {
            str = false;
        }
        else if (dataChild.gameObject.name == "CharBottom" )
        {
            character = false;
        }
        else
        {

        }
    }
}
