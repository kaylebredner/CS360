using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu;
    public TextMeshProUGUI firstColum;
    public GameObject Hand;
    bool itemHeld;
    int prevHeld;
    Keyboard keyboard = Keyboard.current;
    Mouse mouse = Mouse.current;
    GameObject[] inventory = new GameObject[10];
    int currentSlot;
    public GameObject collisionDetect;
    // Start is called before the first frame update
    void Start()
    {
        itemHeld = false;
        inventoryMenu.SetActive(false);
        currentSlot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //opens and closes inventory
        if (keyboard.tabKey.wasPressedThisFrame)
        {
            openInventory();
        }
        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            closeInventory();
        }
        if (keyboard.digit0Key.wasPressedThisFrame)
        {
            currentSlot = 9;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit9Key.wasPressedThisFrame)
        {
            currentSlot = 8;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit8Key.wasPressedThisFrame)
        {
            currentSlot = 7;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit7Key.wasPressedThisFrame)
        {
            currentSlot = 6;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit6Key.wasPressedThisFrame)
        {
            currentSlot = 5;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit5Key.wasPressedThisFrame)
        {
            currentSlot = 4;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit4Key.wasPressedThisFrame)
        {
            currentSlot = 3;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit3Key.wasPressedThisFrame)
        {
            currentSlot = 2;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit2Key.wasPressedThisFrame)
        {
            currentSlot = 1;
            moveItemToHand(currentSlot);
        }
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            currentSlot = 0;
            moveItemToHand(currentSlot);
        }
        if (keyboard.qKey.wasPressedThisFrame)
        {
            currentSlot = 10;
            moveItemToHand(currentSlot);
        }
        if (keyboard.eKey.wasPressedThisFrame)
        {
            dropItem(currentSlot);
        }


    }
    public bool AddToInventory(GameObject item)
    {
        bool itemAdded = false;
        //adds item to first available slot in inventory
        for(int slot = 0; slot < 10; slot++)
        {
            if (inventory[slot] == null)
            {
                Debug.Log("Item Added at slot "+slot);
                inventory[slot] = item;
                itemAdded = true;
                break;
                
            }
            else
            {
                continue;
            }
            
            
        }
        return itemAdded;
    }
    public GameObject[] RetrieveInventory()
    {
        return inventory;
    }
    public void RemoveFromInventory(int slot)
    {
        inventory[slot] = null;
    }
    private void openInventory()
    {
        firstColum.text = "";
        
        for (int slot = 0; slot < 10; slot++)
        {
            if (inventory[slot] != null)
            {
                
                firstColum.text += inventory[slot].gameObject.tag+ " ";
                if (inventory[slot].gameObject.transform.childCount > 0)
                {
                    string[] words = inventory[slot].gameObject.transform.GetChild(0).ToString().Split(' ');
                    firstColum.text += words[0];

                } 
                firstColum.text += "\n";
            }
            else
            {
                firstColum.text += "EMPTY\n";
            }
        }
       
        inventoryMenu.SetActive(true);
    }
    private void closeInventory()
    {
        inventoryMenu.SetActive(false);
    }
    private void moveItemToHand(int held)
    {
        if (held > 9){
            for(int slot = 0; slot < 10; slot++)
            {
                if (inventory[slot] != null)
                {
                    inventory[slot].gameObject.SetActive(false);
                }
                
            }
            itemHeld = false;
            collisionDetect.GetComponent<Pickup>().itemHeld = this.itemHeld;
        }
        else
        {
            if (inventory[held] != null)
            {
                if (inventory[prevHeld] != null)
                {
                    inventory[prevHeld].SetActive(false);
                }

                prevHeld = held;
                inventory[held].gameObject.SetActive(true);
                inventory[held].gameObject.GetComponent<Rigidbody>().isKinematic = true;
                inventory[held].transform.position = Hand.transform.position;
                inventory[held].transform.parent = Hand.transform;
                itemHeld = true;
                collisionDetect.GetComponent<Pickup>().itemHeld = this.itemHeld;
                
            }
        }
    }
    private void dropItem(int held)
    {
        if (itemHeld)
        {
            if (inventory[held] != null)
            {
                inventory[held].gameObject.GetComponent<Rigidbody>().isKinematic = false;

                inventory[held].transform.parent = null;
                itemHeld = false;
                collisionDetect.GetComponent<Pickup>().itemHeld = this.itemHeld;
                RemoveFromInventory(held);
            }
            
        }
        
    }
}
