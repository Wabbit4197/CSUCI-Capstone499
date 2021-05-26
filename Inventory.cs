using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject[] inventory = new GameObject[100];
    
    public void AddItem(GameObject item){

        bool itemAdded = false;
        // Find the first open slot in the inventory
        for (int i =0; i< inventory.Length; i++){
            if(inventory[i] == null){
                inventory [i] = item;
                Debug.Log (item.name + "was added");
                itemAdded = true;
                break;
            }
        }

        //Inventory full
        if (!itemAdded){
            Debug.Log ("inventory full, item not added");
        }
    }

    public bool FindItem(GameObject item){
        for(int i=0; i<inventory.Length; i++){
            if (inventory[i] == item){
                // we find the item we looking for 
                return true;
            }
        }
        return false;
    }
}
