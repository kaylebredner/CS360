using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayMatchParent : MonoBehaviour
{
    public GameObject door;
    int[] passArray = new int[5];
    int[] passInput = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        passArray[0] = 20;
        passArray[1] = 11;
        passArray[2] = 27;
        passArray[3] = 0;
        passArray[4] = 92;
    }

    // Update is called once per frame
    public void ArrayInsert(int value, int place)
    {
        Debug.Log("value "+ value+"position "+place);
        passInput[place] = value;
        if (ArrayCheck())
        {
            door.SetActive(false);
        }
    }
    public void ArrayRemove( int place)
    {
        passInput[place] = 100;
        
    }
    private bool ArrayCheck()
    {
        string debug="";
        for(int place = 0; place < 5; place++)
        {
            debug += place;
            debug += " ";
            debug += passInput[place];
            Debug.Log(debug);
            if (passInput[place] != passArray[place])
            {
                
                return false;
            }
        }
        return true;
    }
}
