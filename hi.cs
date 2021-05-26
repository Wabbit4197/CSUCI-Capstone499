using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hi : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
                print("i touch you ");
            
    }
        


    void OnTriggerEnter2D(Collider2D collisions)
    {
            if (collisions.gameObject.CompareTag("Player"))
                print("i touch you 2");
    }


}
