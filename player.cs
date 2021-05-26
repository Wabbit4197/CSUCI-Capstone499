using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class player : MonoBehaviour
{
    //public static player instance;
    //public static List<GameObject> mylist = new List<GameObject>();
    //List<GameObject> list1= new List<GameObject>();
    //public static List<bool> boollist = new List<bool>();
    //public static List<GameObject> itemlist;
    
    public AudioClip pickupsound;
    //public GameItem mygameitem;
    public Text endtext;

    public static int maxmana;
    public bool canend;

    public static bool cantp5;
    public static bool cantp10;
    public static bool cantp15;


    public static bool canskill = false;
    public AudioClip fight;

    public AudioClip opendoor;

    public AudioClip purchase;
    AudioSource audioSource;

    public unlockdoor unlock;

    public GameObject skillmenu;

    //public Text enoughmana;
    public static bool canheal = false; 

    public float DamageCalculation;
    
    public static int healthvalue = 100;
    public static int maxhp = 100;

    public static bool respawn = false;

    public static bool destroy = false;
    [SerializeField] public static bool canfireball = false;
    [SerializeField] public static bool revertstat = false;

    public static int attackvalue = 40;
    public static int defensevalue =30;
    public static int manavalue = 0;

    public static int currentfloor;

    public static int gold = 100;
    // above optional;
    public int damageStrength;
    

    //public int tester ;

    private int nextSceneToLoad;
    //public dialogtrigger trigger;

    private int previousSceneToLoad;
    public int damagedealt;

    Vector3 startPos;

    //var map = new Dictionary<GameObject, bool>();

    public void Start()
	{
        if(skillmenu.activeInHierarchy){
            skillmenu.SetActive(false);
        }

        //endtext.gameObject.SetActive(false);
        //var array1 = new ArrayList();
        //var array2 = new List<>();
        //List<List<GameObject>> array2 = new List<List<GameObject>>();
        audioSource = GetComponent<AudioSource>();
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex +1;
        previousSceneToLoad = SceneManager.GetActiveScene().buildIndex -1;

        //if(itemlist[SceneManager.GetActiveScene().buildIndex]!=null){
    
        //}
        
        
        

        
        
	}

    public void Update()
    {
        //SavePlayer();
        //Position();

         if (Input.GetKeyDown(KeyCode.H))
        {
            Goldmanager.GoldAmount +=100;
            healthvalue += 100; 
            print("hitpoint is " + healthvalue);
            healthbar.healthpointAmount = healthvalue;
            print("healthbar is "+ healthbar.healthpointAmount);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            //attackvalue -=10;
            maxhp +=150;
        }

         if (Input.GetKeyDown(KeyCode.L))
        {
            if(Goldmanager.GoldAmount >=100){
            Attackstatus.playerattack +=4;
            attackvalue+=4;
            }
        }   

        if (Input.GetKeyDown(KeyCode.P))
        {
            Keymanager.yellowkeyAmount+=1;
            Keymanagerblue.bluekeyAmount +=1;
            Keymanagerred.redkeyAmount +=1;
            
        }

        if(respawn)
        {
            SceneManager.LoadScene("inn");
            respawn = false;
        }

        if (Input.GetKey(KeyCode.Q)){
            if(manavalue>=1){
                canskill = true;
            }

            skillmenu.SetActive(true);
            //SkillActivate();
            //if(manavalue>=1){
            //fireball();
               // if (Input.GetKeyDown(KeyCode.Q)){
                  //  heal();
                   // canfireball = false;
                //}
            Debug.Log("skill is activeing");
            
        }

        if(revertstat){
            attackvalue -=30;
            revertstat = false;
        }

        if(Input.GetKeyDown(KeyCode.R)){
            manavalue+=1;
            Keymanager.yellowkeyAmount += 1;
            Debug.Log("im adding mana"+ manavalue);

        }

        if(canskill){
            if(Input.GetKeyDown(KeyCode.Alpha1)&&canfireball==true){
                Debug.Log("u already cast fireball");
                }

            if(Input.GetKeyDown(KeyCode.Alpha1)&&canfireball!=true){
                fireball();
                print("im using fireball");
                canskill =  false;
                skillmenu.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                heal();
                print("im using heal");
                canskill = false;
                skillmenu.SetActive(false);
            }   
        }

         if(Input.GetKeyDown(KeyCode.Tab)){
                print("cancel skill");
                canskill = false;
                skillmenu.SetActive(false);
            }

        if(canend){
        endtext.gameObject.SetActive(true);
        }
        /*if(mylist!=null){
            foreach(GameObject list in mylist){
                Debug.Log("current list are" + list);
                //Destroy(list);
            }
        }
        */
        
        

        /*healthvalue = healthvalue;
        maxhp = maxhp;
        attackvalue = attackvalue;
        defensevalue =defensevalue;
        gold = Goldmanager.GoldAmount;
        */

        //Debug.Log("HP " + healthvalue);
        //Debug.Log("MAXHP " + maxhp);
        //Debug.Log("Gold " + gold);
        //Debug.Log("Keys " + yellowkey + bluekey + redkey);
        //Debug.Log("attack" + attackvalue);
        //Debug.Log("MAXHP" +defensevalue);
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("canbepickup"))
        {
            
             Item hitObject = collision.gameObject.GetComponent<consumable>().item;
           // mylist.Add(collision.gameObject);

            if (hitObject != null)
            {
                print("Hit: " + hitObject.objectName);
                audioSource.PlayOneShot(pickupsound,0.9f);
                switch (hitObject.itemType)
                {
                    
                    case Item.ItemType.yellowkey:
                        Keymanager.yellowkeyAmount +=1;
                        //Debug.Log("Its game " + collision.gameObject.GetComponent<GameItem>().destroy);
                        //collision.gameObject.GetComponent<GameItem>().destroy = true;
                        
                        //Debug.Log("its spawn " + collision.gameObject.GetComponent<SpawnedGameItem>().destroy);
                        //collision.gameObject.GetComponent<SpawnedGameItem>().destroy = true;
                        //mygameitem.destory = true;
                        break;
                    
                    case Item.ItemType.bluekey:
                        Keymanagerblue.bluekeyAmount +=1;
                        break;

                    case Item.ItemType.redkey:
                        Keymanagerred.redkeyAmount +=1;
                        break;

                    case Item.ItemType.redheart:
                        AdjustHitPoints(hitObject.quantity);
                        // the hitpoint quantity will be store as amount in the AdjustHitPoint function
                        //collision.gameObject.SetActive(false);
                        break;

                    case Item.ItemType.blueheart:
                        AdjustMaxHitPoints(hitObject.quantity);

                        break;

                    case Item.ItemType.attackcrystal:
                        Adjustplayerattack(hitObject.quantity);
                        break;
                    
                    case Item.ItemType.defensecrystal:
                        Adjustplayerdefense(hitObject.quantity);
                        break;


                    default:
                        break;
                }
            
            collision.gameObject.SetActive(false);
            
            }
        }
    
        if (collision.gameObject.CompareTag("enemy"))
        {
           Enemytype hitobject = collision.gameObject.GetComponent<Enemystats>().enemytype;

           if (hitobject != null)
            {
                audioSource.PlayOneShot(fight,0.9f);
                //display enemy type
                //print("Hit: " + hitobject.objectName);
                //initialize the enemy hp
                //hitobject.enemystartinghp = hitobject.enemymaxhp;
                //player take damage
                    DamageCalculation = Mathf.Ceil((float)hitobject.enemystartinghp/(float)(attackvalue-hitobject.enemydefense))*(hitobject.enemyattack-defensevalue);
                    Debug.Log("Ceil expected damage is " + DamageCalculation);
                
                
                while(hitobject.enemystartinghp>0)
                {
                    damageStrength = hitobject.enemyattack - player.defensevalue; 
                    if(damageStrength<0){
                        damageStrength=0;
                    }
                    //print("i will LOSE HEALTH " + damageStrength);
                    //print("Enemey attack is "+ hitobject.enemyattack + " and my defense is  " + defensevalue);
                    //Debug.Log ("DEBUG1 my current hitpoint " + healthvalue);
                    player.healthvalue -= damageStrength;
                    //Debug.Log ("DEBUG2 my current hitpoint " + healthvalue);
                    //healthvalue = player.healthvalue;
                    //Debug.Log ("DEBUG3 my current hitpoint " + healthvalue);

                    //print("my current health " + healthvalue);
                    //kill player if below 0 health
                    if(player.healthvalue <=0){
                        player.healthvalue =0;
                        //KillCharacter();
                        respawn = true;

                    }
                    //reflect damage
                    damagedealt = player.attackvalue - hitobject.enemydefense;

                    //print("the enemy current hp is " + hitobject.enemystartinghp);
                    //Player 40 attack, 30 defense, 100 hp.        Enemy 35 attack, 10 defense, 100hp.
                    //Expected health lose = ((enemyhp/ damagedealt)+1) * (enemy attack - player defense) Expect lose  health; 

                    hitobject.enemystartinghp -= damagedealt;

                    //print("My attack power is " + attackvalue + " and the enemy defense is " + hitobject.enemydefense);

                    //print("The damage dealt is " + damagedealt);

                    //print("the enemy hp after hit is " + hitobject.enemystartinghp);
                }

                if(hitobject.enemystartinghp <= 0)
                {
                    if(canfireball){
                    Goldmanager.GoldAmount += hitobject.gold;
                    print("The current attack with fireball is " + attackvalue);
                    collision.gameObject.SetActive(false);
                    hitobject.enemystartinghp = hitobject.enemymaxhp;
                    revertstat = true;
                    Debug.Log ("set revert stat to true to reduce player attack");
                    canfireball = !canfireball;
                    Debug.Log("revert canfireball bool so it can not be cast again");
                    }

                    else{
                    Goldmanager.GoldAmount += hitobject.gold;
                    //print("The current gold is " + Goldmanager.GoldAmount);
                    collision.gameObject.SetActive(false);
                    hitobject.enemystartinghp = hitobject.enemymaxhp;
                    }
                }
                    //if enemy healthpoint=0, destory object.
                    //case Enemytype.Enemytypes.bat:
                    // damageStrength = hitobject.enemyattack - player.defensevalue; 
                    // print("i LOSE HEALTH");
                    // player.healthvalue -= damageStrength;
                    // break;           
            }
        }

        if (collision.gameObject.CompareTag("Stella"))
        {
           Enemytype hitobject = collision.gameObject.GetComponent<Enemystats>().enemytype;
            
           if (hitobject != null)
            {
                audioSource.PlayOneShot(fight,0.9f);
                    
                while(hitobject.enemystartinghp>0)
                {
                    damageStrength = hitobject.enemyattack - player.defensevalue; 

                    player.healthvalue -= damageStrength;
                    
                    if(player.healthvalue <=0){
                        player.healthvalue =0;
                        respawn = true;
                    }

                    damagedealt = player.attackvalue - hitobject.enemydefense;
                    hitobject.enemystartinghp -= damagedealt;
                }
                if(hitobject.enemystartinghp <= 0)
                {
                    Goldmanager.GoldAmount += hitobject.gold;
                    //Destroy(unlock.door1);
                    //Destroy(unlock.door2);
                    //Destroy(unlock.door3);
                    //Destroy(unlock.door4);
                    Debug.Log("I beat stella");
                    //print("The current gold is " + Goldmanager.GoldAmount);
                    collision.gameObject.SetActive(false);
                    Debug.Log("add mana 1");
                    Keymanagerblue.bluekeyAmount+=4;
                    manavalue +=1;
                    maxmana+=1;
                    cantp5 = true;
                    hitobject.enemystartinghp = hitobject.enemymaxhp;
                }
                             
            }
        }

        if (collision.gameObject.CompareTag("momo"))
        {
           Enemytype hitobject = collision.gameObject.GetComponent<Enemystats>().enemytype;
            
           if (hitobject != null)
            {
                audioSource.PlayOneShot(fight,0.9f);
                    
                while(hitobject.enemystartinghp>0)
                {
                    damageStrength = hitobject.enemyattack - player.defensevalue; 

                    player.healthvalue -= damageStrength;
                    
                    if(player.healthvalue <=0){
                        player.healthvalue =0;
                        respawn = true;
                    }

                    damagedealt = player.attackvalue - hitobject.enemydefense;
                    hitobject.enemystartinghp -= damagedealt;
                }
                if(hitobject.enemystartinghp <= 0)
                {
                    Goldmanager.GoldAmount += hitobject.gold;
                    //Destroy(unlock.door1);
                    //Destroy(unlock.door2);
                    //Destroy(unlock.door3);
                    //Destroy(unlock.door4);
                    Debug.Log("I beat momo");
                    //print("The current gold is " + Goldmanager.GoldAmount);
                    collision.gameObject.SetActive(false);
                    Debug.Log("add mana 1");
                    manavalue +=1;
                    maxmana+=1;
                    cantp10=true;
                    hitobject.enemystartinghp = hitobject.enemymaxhp;
                    canheal = true;
                }
                             
            }
        }

        if (collision.gameObject.CompareTag("SlimeKing"))
        {
           Enemytype hitobject = collision.gameObject.GetComponent<Enemystats>().enemytype;
            
           if (hitobject != null)
            {
                audioSource.PlayOneShot(fight,0.9f);
                    
                while(hitobject.enemystartinghp>0)
                {
                    damageStrength = hitobject.enemyattack - player.defensevalue; 

                    player.healthvalue -= damageStrength;
                    
                    if(player.healthvalue <=0){
                        player.healthvalue =0;
                        respawn = true;
                    }

                    damagedealt = player.attackvalue - hitobject.enemydefense;
                    hitobject.enemystartinghp -= damagedealt;
                }
                if(hitobject.enemystartinghp <= 0)
                {
                    Goldmanager.GoldAmount += hitobject.gold;
                    //Destroy(unlock.door1);
                    //Destroy(unlock.door2);
                    //Destroy(unlock.door3);
                    //Destroy(unlock.door4);
                    Debug.Log("I beat SlimeKing");
                    //print("The current gold is " + Goldmanager.GoldAmount);
                    collision.gameObject.SetActive(false);
                    Debug.Log("add mana 1");
                    manavalue +=1;
                    maxmana+=1;
                    cantp15=true;
                    hitobject.enemystartinghp = hitobject.enemymaxhp;
                    canheal = true;
                }
                             
            }
        }

        if (collision.gameObject.CompareTag("ZombieDragon"))
        {
           Enemytype hitobject = collision.gameObject.GetComponent<Enemystats>().enemytype;
            
           if (hitobject != null)
            {
                audioSource.PlayOneShot(fight,0.9f);
                    
                while(hitobject.enemystartinghp>0)
                {
                    damageStrength = hitobject.enemyattack - player.defensevalue; 

                    player.healthvalue -= damageStrength;
                    
                    if(player.healthvalue <=0){
                        player.healthvalue =0;
                        respawn = true;
                    }

                    damagedealt = player.attackvalue - hitobject.enemydefense;
                    hitobject.enemystartinghp -= damagedealt;
                }
                if(hitobject.enemystartinghp <= 0)
                {
                    Goldmanager.GoldAmount += hitobject.gold;
                    //Destroy(unlock.door1);
                    //Destroy(unlock.door2);
                    //Destroy(unlock.door3);
                    //Destroy(unlock.door4);
                    Debug.Log("I beat the Game");
                    //print("The current gold is " + Goldmanager.GoldAmount);
                    collision.gameObject.SetActive(false);
                    canend = true;
                    //endtext.gameObject.SetActive(true);
                    Debug.Log("add mana 1");
                    manavalue +=1;
                    maxmana+=1;
                    hitobject.enemystartinghp = hitobject.enemymaxhp;
                    canheal = true;
                }
                             
            }
        }

        if (collision.gameObject.CompareTag("door"))
        {
            door hitdoor = collision.gameObject.GetComponent<doortrigger>().GetDoortype;
            if (hitdoor != null)
            {
                print("Hit: " + hitdoor.objectName);
                switch(hitdoor.doors){
                    case door.DoorTypes.yellodoor:
                        if(Keymanager.yellowkeyAmount>=1){
                            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                            audioSource.PlayOneShot(opendoor,0.9f);
                            Keymanager.yellowkeyAmount -=1;
                            collision.gameObject.SetActive(false);
                        }

                        else{
                            //change the movement script, if the object ahead is a tag with door, 
                            //check if the player has the corresponding key, restrict movement 
                            //toward that direction if no key. 
                            //this.transform.position = startPos;
                            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                            print("Can't enter without a key");
                            }
                        break;

                    case door.DoorTypes.bluedoor:
                        if(Keymanagerblue.bluekeyAmount>=1){
                            audioSource.PlayOneShot(opendoor,0.9f);
                            Keymanagerblue.bluekeyAmount -=1;
                            collision.gameObject.SetActive(false);
                        }

                        else{
                            //change the movement script, if the object ahead is a tag with door, 
                            //check if the player has the corresponding key, restrict movement 
                            //toward that direction if no key. 

                            //print("Can't enter without a key");
                            }
                        break;

                    case door.DoorTypes.reddoor:
                        if(Keymanagerred.redkeyAmount>=1){
                            audioSource.PlayOneShot(opendoor,0.9f);
                            Keymanagerred.redkeyAmount -=1;
                            collision.gameObject.SetActive(false);
                        }

                        else{
                            //change the movement script, if the object ahead is a tag with door, 
                            //check if the player has the corresponding key, restrict movement 
                            //toward that direction if no key. 

                            //print("Can't enter without a key");
                            }    
                        break;
        

                    default:
                    break;
                }
            }
        }

        /*if (collision.gameObject.CompareTag("NPC")){
            print("hi");
           
            //trigger.TriggerDialogue();
        }
        */
        

        //braek;
        if (collision.gameObject.CompareTag("nextscene")){
            SceneManager.LoadScene(nextSceneToLoad);
        }

        if (collision.gameObject.CompareTag("previousscene")){
            SceneManager.LoadScene(previousSceneToLoad);
        }
    }


   public void AdjustHitPoints(int amount)
    {
        //print("hit object amount is " + amount);
        //print("check my hitpoint" + healthvalue);
        healthvalue = healthvalue + amount;
        //print("check my hitpoint" + healthvalue);
        
        //healthbar.healthpointAmount +=amount;
        //print("healthbarvalue:" + healthbar.healthpointAmount);
        if(healthvalue > maxhp)
        {
        healthvalue = maxhp;
        //print("player hp cannot exceed maximum hp " + healthvalue );
        }

        //print("Adjusted hitpoints by: " + amount + ". New value: " + healthvalue);
        //print("current hp" + healthvalue);

        
        
    }

    public void AdjustMaxHitPoints(int amount)
    {

        maxhp = maxhp +amount;
        
        
        //healthbar.healthpointAmount +=amount;
        //print("healthbarvalue:" + healthbar.healthpointAmount);
        
        //print("Adjusted maxhp by: " + amount + ". New value: " + maxhp);
        //print("current maxhp" + maxhp);
    }
    

    public void Adjustplayerattack(int amount)
    {
        attackvalue = attackvalue + amount;
        //print ("Adjust attackvalue by " + amount + "New value" + attackvalue);
        //print("current attackvalue" + attackvalue);
    }
    
    public void Adjustplayerdefense(int amount)
    {
       defensevalue =defensevalue + amount;
        //print ("Adjust attackvalue by " + amount + "New value" +defensevalue);

        //print("current defense is" + defensevalue);
    }

    public void fireball (int TempAttack = 30){

        if(manavalue>=1){
        Debug.Log("current attack" + attackvalue );
        attackvalue = attackvalue+TempAttack;
        Debug.Log("enpower with fireball attack" + attackvalue );
        manavalue -=1;
        Debug.Log("lose mana");
        canfireball = true;
        Debug.Log("set canfireball bool to true");
        }
    }

    public void heal (int heal = 30){
        if(manavalue>=1){
        player.healthvalue = player.maxhp;
        Debug.Log("im healing" + healthvalue );
        Debug.Log("lose mana");
        manavalue -=1;
        }
    }
    
    public void SkillActivate(){
        Debug.Log("I am lookfor skill list");
        if(player.manavalue >=1){
            Debug.Log("trigger fireball");
            fireball();
        }

        else{
            Debug.Log("you have no mana");
            return;
        }
    }
    public void Position()
    {
         startPos = this.transform.position;        
    }

  

    /*public void Savemygame()
    {
        savegame.SavePlayer(this);
        Debug.Log("save button is clicked and saved");

        Debug.Log("SavedHP " + playerdata.healthvalue);
        Debug.Log("SavedMAXHP " + playerdata.maxhp);
        Debug.Log("SavedGold " + playerdata.gold);
        Debug.Log("SavedKeys " + playerdata.yellowkey + playerdata.bluekey + playerdata.redkey);
        Debug.Log("Savedattack" + playerdata.attackvalue);
        Debug.Log("SavedMAXHP" + playerdata.defensedefensevalue);
    }

    public void Loadmygame()
    {
        playerdata data = savegame.LoadPlayer();
        healthvalue = playerdata.healthvalue;
        maxhp = playerdata.maxhp;
        gold = playerdata.gold;
        yellowkey = playerdata.yellowkey;
        bluekey = playerdata.bluekey;
        redkey = playerdata.redkey;
        mana = playerdata.mana;
        attackvalue = playerdata.attackvalue;
       defensevalue = playerdata.defensedefensevalue;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        //transform.position = position;

        Debug.Log("CurrentHP " + healthvalue);
        Debug.Log("CurrentMAXHP " + maxhp);
        Debug.Log("CurrentGold " + gold);
        Debug.Log("CurrentKeys " + yellowkey + bluekey + redkey);
        Debug.Log("Currentattack" + attackvalue);
        Debug.Log("Currentdefense" +defensevalue);
    }

*/
    
    /*public override void ResetCharacter()
    {
        healthvalue = 0;
    }
    */
}