using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeinlist : MonoBehaviour
{
    //player players;
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("Player"))
       {
           destroyonload.mylist.Add(gameObject);

       }
   }
}
