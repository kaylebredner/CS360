using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class SignUpdate : MonoBehaviour
{
    public TextMeshPro signTxt;
    public GameObject player;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        signTxt.text = "Player movement speed is: " + player.GetComponent<FirstPersonController>().MoveSpeed;
        if (player.GetComponent<FirstPersonController>().MoveSpeed <= 4)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
        
    }
}
