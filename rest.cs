using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rest : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject inn;
    public Text hotelcost;

    //public static int multiplier =1;
    public static int cost ;
    public static int nextcost;
    public bool isrest;
    void Start()
    {
        
        if(inn.activeInHierarchy){
                inn.SetActive(false);
            }
    }
    
    void Update()
    {
        hotelcost.text = (cost+40).ToString();
        if(isrest && Input.GetKeyDown(KeyCode.Z)){
            //print("multiplier is" + multiplier);
            
            //nextcost = cost+40;
            //print("the cost is " + cost);
            //cost = 40*multiplier;
            if(Goldmanager.GoldAmount >= (cost+40)){
                
                //cost = 40;
                cost = cost +40;
                //multiplier +=1;
                //Debug.Log("next cost is " + nextcost);
                //hotelcost.text = nextcost.ToString();
                Debug.Log("cost is " + cost);
                Goldmanager.GoldAmount -=cost;
                player.healthvalue = player.maxhp;
                player.manavalue = player.maxmana;
                healthbar.healthpointAmount = player.maxhp;
            }

            else{
                print("not enough gold");
            }
            
            //Goldmanager.GoldAmount -=40*multiplier;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            isrest=true;
            Debug.Log("Player touch me");
            inn.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            isrest=false;
            inn.SetActive(false);
            Debug.Log("Player left me");
        }
    }
}
