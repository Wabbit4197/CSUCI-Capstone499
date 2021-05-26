using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class altar : MonoBehaviour
{
    public GameObject myaltar;
    public bool canshop;
    public Text altarcost;
    public static int cost =40;

    public static int multiplier = 1;

    
    void Start(){
        myaltar.SetActive(false);
        print("make altar disappear");

    }

    
    void Update()
    {
        altarcost.text = (cost).ToString();
        if(canshop)
        {
            Debug.Log("cost is " + cost);
            if(Goldmanager.GoldAmount >= (cost)){
                
                //cost = 40;
                //multiplier +=1;
                //Debug.Log("next cost is " + nextcost);
                //hotelcost.text = nextcost.ToString();
                Debug.Log("new cost " + cost);
                
                if(Input.GetKeyDown(KeyCode.Z)){
                    attack();
                    Goldmanager.GoldAmount -=cost;
                    cost = cost +40;
                }

                if(Input.GetKeyDown(KeyCode.X)){
                     defense();
                    Goldmanager.GoldAmount -=cost;
                    cost = cost +40;
                }

                if(Input.GetKeyDown(KeyCode.C)){
                    maxhp();
                    Goldmanager.GoldAmount -=cost;
                    cost = cost +40;
                }

                if(Input.GetKeyDown(KeyCode.V)){
                    currenthealth();
                    Goldmanager.GoldAmount -=cost;
                    cost = cost +40;
                }
            }
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            canshop=true;
            Debug.Log("Customer buying");
            myaltar.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            canshop=false;
            myaltar.SetActive(false);
            Debug.Log("Customer gone");
        }
    }

    public void attack(){
      
        player.attackvalue+=2;
    }
    public void defense(){
       // print("im here");
       player.defensevalue+=2;
       print("player defense is " + player.defensevalue);
       print("UI defense is  " + Defensestatus.playerdefense);

       Defensestatus.playerdefense = player.defensevalue;
    }


    public void maxhp(){
       player.maxhp+=100;
       print("im here");
       Debug.Log("player maxhp is " + player.maxhp);
       healthbar.maxhealthpointAmount = player.maxhp;
    }

    public void currenthealth(){
        player.healthvalue+=140;
        Debug.Log("player health is " + player.healthvalue);
        if(player.healthvalue > player.maxhp){
            player.healthvalue = player.maxhp;
        }
    }

    public void Menu()
    {
        Debug.Log("clicked it");

    }
}
