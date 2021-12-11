using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMatchChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        int place=0;
        int value=100;
        if (this.tag == "0")
        {
            Debug.Log('0');
            place = 0;
        }
        else if(this.tag == "1")
        {
            place = 1;
        }
        else if(this.tag == "2")
        {
            place = 2;
        }
        else if(this.tag == "3")
        {
            place = 3;
        }
        else if(this.tag == "4")
        {
            place = 4;
        }
        if (other.gameObject.layer == 6)
        {
            string[] number;
            string temp;
            temp = (other.gameObject.name);
            number = temp.Split(' ');
            value = int.Parse(number[0]);
            transform.parent.parent.GetComponent<ArrayMatchParent>().ArrayInsert(value, place);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            int place = 0;
            if (this.tag == "0")
            {
                place = 0;
            }
            else if (this.tag == "1")
            {
                place = 1;
            }
            else if (this.tag == "2")
            {
                place = 2;
            }
            else if (this.tag == "3")
            {
                place = 3;
            }
            else if (this.tag == "4")
            {
                place = 4;
            }
            transform.parent.parent.GetComponent<ArrayMatchParent>().ArrayRemove(place);
        }
    }
}
