using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Doortype")]
public class door : ScriptableObject {

    public string objectName;
    public Sprite sprite;
     
    public enum DoorTypes
    {
        yellodoor,

        bluedoor,

        reddoor,

        crystaldoor
        
    }

    public DoorTypes doors;
}