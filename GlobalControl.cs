using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour 
{
    public static GlobalControl Instance;
    public int hitPoints ;
    public int maxHitPoints ;
    public int gold;
    public int yellowkey;
    public int bluekey;
    public int redkey;
    public int mana;
    public int attackpower;
    public int defensepower;

    public int test;

    void Awake ()   
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
}
