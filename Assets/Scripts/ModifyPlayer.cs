using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModifyPlayer : MonoBehaviour
{
    public GameObject player;
    string variableName;
    bool varNameChange;
    double variableValue;
    bool varValChange;
    // Start is called before the first frame update
    void Start()
    {
        varNameChange = false;
        varValChange = false;
    }

    // Update is called once per frame
    public void PassObject( string val, bool change) 
    {
        
        variableName = val;
        varNameChange = change;
        UpdatePlayer();
    }
    public void PassObject( double val, bool change)
    {
        variableValue = val;
        varValChange = change;
        UpdatePlayer();
    }
    private void UpdatePlayer()
    {
        if (varNameChange && varValChange)
        {
            player.GetComponent<FirstPersonController>().MoveSpeed = (float)variableValue;
            player.GetComponent<FirstPersonController>().SprintSpeed = 1.5f * (float)variableValue;
        }
    }

}
