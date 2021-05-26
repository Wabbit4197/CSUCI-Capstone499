using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addredkey : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player")){
          print("player pickup the treasure");
          Keymanagerred.redkeyAmount+=3;
          this.gameObject.SetActive(false);
      }

    }
}
