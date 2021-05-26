using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemytype")]
public class Enemytype : ScriptableObject {

    public string objectName;
    public Sprite sprite;

    public int enemystartinghp;
    public int enemyattack;
    public int enemydefense;

    public int enemymaxhp;

    public int gold;

    public enum EnemyTypes
    {
        slime,
        bat,
        skeleton, 
        red_slime,

        sheep,
        golem,
        greendevil,
        browndevil,
        fox,
        bird,
        cat,
        horse,
        mushroom,
        jellyfish,
        troll,
        salamander,
        harpy,
        pig,
        evilbat,
        fakechest,
        hellrock,
    
        

        Stella,
        Momo,
        slimeking,
        ZombieDragon
    }

    public EnemyTypes enemytype;
}
