using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class IfStatementCheck : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void CheckIf(bool leverState)
    {
        if (leverState)
        {
            player.GetComponent<FirstPersonController>().MoveSpeed/=2;
            player.GetComponent<FirstPersonController>().SprintSpeed =1.5f* player.GetComponent<FirstPersonController>().MoveSpeed;
        }
        else
        {
            player.GetComponent<FirstPersonController>().MoveSpeed = 8;
            player.GetComponent<FirstPersonController>().SprintSpeed = 1.5f * player.GetComponent<FirstPersonController>().MoveSpeed;
        }
    }
}
