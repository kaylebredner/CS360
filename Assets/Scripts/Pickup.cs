using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public GameObject Hand;
    bool canPickUp;
    public bool itemHeld;
    GameObject heldObject;
    Keyboard keyboard = Keyboard.current;
    public Text alert;
    bool door;
    GameObject currentDoor;
    GameObject currentSwitch;
    public bool lever;
    void Start()
    {
        alert.text = "";
        canPickUp = false;
        itemHeld = false;
        door = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        //detects if user is close enough to a door or interactable object
        if (canPickUp||itemHeld)
        {
            if (keyboard.eKey.wasPressedThisFrame)
            {
                if (itemHeld&&heldObject!=null)
                {
                    alert.text = "";
                    heldObject.GetComponent<Rigidbody>().isKinematic = false;
                    heldObject.transform.parent = null;
                    itemHeld = false;
                }
                else if(heldObject!=null)
                {
                    alert.text = "Press \"E\" to drop";
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                    heldObject.transform.position = Hand.transform.position;
                    heldObject.transform.parent = Hand.transform;
                    itemHeld = true;
                }
                
                
            }

        }
        else if (door)
        {
            if (keyboard.eKey.wasPressedThisFrame)
            {
                currentDoor.SetActive(false);
                alert.text = "";
            }
                
        }
        else if (lever){
            if (keyboard.eKey.wasPressedThisFrame)
            {
                lever = false;
                Toggle(currentSwitch);
                alert.text = "";
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("playerCollided");
        bool itemAdded;
        if (!itemHeld)
        {
            //detects if the player is near an object that can be picked up

            if (other.gameObject.layer == 3)
            {
                alert.text = "Press \"E\" to pick up";
                canPickUp = true;
                heldObject = other.gameObject;
            }
            //collects collectables when walked over
            if (other.gameObject.layer == 6)
            {
                itemAdded = transform.parent.GetComponent<Inventory>().AddToInventory(other.gameObject);
                if (itemAdded)
                {
                    other.gameObject.SetActive(false);
                }
                
            }
            //allows player to open doors
            if (other.gameObject.layer == 7){
                alert.text = "Press \"E\" to open";
                door = true;
                currentDoor=other.gameObject;
            }
            //allows the palyerr to flip switches
            if (other.gameObject.layer == 9)
            {
                alert.text = "Press \"E\" to flip";
                lever = true;
                currentSwitch = other.gameObject;
            }
        }
        
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        //resets booleans and alert text when user is no longer close enough to an object;
        alert.text = "";
        door = false;
        canPickUp = false;
    }
    private void Toggle(GameObject gameObject)
    {
        if (gameObject.transform.GetChild(0).gameObject.activeSelf == true){
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
