using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public bool inventory; // if true this object can be store in inventory
    public GameObject itemNeeded;
    public void DoInteraction(){
        gameObject.SetActive (false);
    }
}
