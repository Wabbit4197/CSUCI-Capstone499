using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character : MonoBehaviour 
{ //remove abstract

    public int hitPoints  ;
    public int maxHitPoints  ;
    //public int gold ;
    public int yellowkey ;
    public int bluekey;
    public int redkey;
    public int mana;
    public int attackpower;
    public int defensepower ;


    public int test =5;

    public int startingHitPoints;

    public virtual void KillCharacter()
        {
            Destroy(gameObject);
        }
    //public abstract void ResetCharacter();
    //public abstract IEnumerator DamageCharacter(int damage, float interval);
}


