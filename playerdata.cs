using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class playerdata 
{
    public static int hitPoints  ;
    public static int maxHitPoints  ;
    public static int gold ;
    public static int yellowkey ;
    public static int bluekey;
    public static int redkey;
    public static int mana;
    public static int attackpower;
    public static int defensepower ;

    public float[] position;

    public playerdata (player player)
    {
    
        hitPoints = player.healthvalue;
        maxHitPoints = player.maxhp;
        gold = player.gold;
        yellowkey = Keymanager.yellowkeyAmount;
        bluekey = Keymanagerblue.bluekeyAmount;
        redkey = Keymanagerred.redkeyAmount;
        mana = player.manavalue;
        attackpower = player.attackvalue;
        defensepower = player.defensevalue;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
    // Start is called before the first frame update
    
