using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1
public class Enemy : Character
{

    public bool shoulddestroy= false;

    public int damageStrength;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            shoulddestroy = true;

            print("you should destory on next load"+ other.gameObject);
        }
            
    }
}

 
