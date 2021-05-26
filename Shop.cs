using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Shop : MonoBehaviour
{
    public GameObject shop;
    public bool canshop;

    public GameObject myshortsword;
    public GameObject mylongsword;
    public GameObject mylightshield;
    public GameObject myheavyshield;

    public GameObject shortswordbutton;
    public GameObject longswordbutton;
    public GameObject lightshieldbutton;
    public GameObject heavyshieldbutton;



    void Start(){
        shop.SetActive(false);
        print("make shop disappear");

    }

    
    void Update()
    {
        if(canshop)
        {
            if(Input.GetKeyDown(KeyCode.Z)){
                sword();
                
            }

            if(Input.GetKeyDown(KeyCode.X)){
                longsword();
            
            }

            if(Input.GetKeyDown(KeyCode.C)){
                shield();
                
            }

            if(Input.GetKeyDown(KeyCode.V)){
                hardshield();
            
            }
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            canshop=true;
            Debug.Log("Customer buying");
            shop.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            canshop=false;
            shop.SetActive(false);
            Debug.Log("Customer gone");
        }
    }

    public void sword(){
        //if(canshop){
        if(Goldmanager.GoldAmount>=200 && myshortsword.activeInHierarchy){
        player.attackvalue +=4;
        Goldmanager.GoldAmount -=200;
        myshortsword.SetActive(false);
        shortswordbutton.SetActive(false);
            }
        //}
    }
    public void shield(){
        //if(canshop){
            if(Goldmanager.GoldAmount>=200 && mylightshield.activeInHierarchy){
        player.defensevalue +=4;
        Goldmanager.GoldAmount -=200;
        mylightshield.SetActive(false);
        lightshieldbutton.SetActive(false);
        }
        //}
    }


    public void longsword(){
        //if(canshop){
        if(Goldmanager.GoldAmount>=500 && mylongsword.activeInHierarchy){
        player.attackvalue +=6;
        Goldmanager.GoldAmount -=500;
        mylongsword.SetActive(false);
        longswordbutton.SetActive(false);
        }
        //}
    }

    public void hardshield(){
        //if(canshop){
            if(Goldmanager.GoldAmount>=500 && myheavyshield.activeInHierarchy){
                player.defensevalue +=6;
                Goldmanager.GoldAmount -=500;
                myheavyshield.SetActive(false);
                heavyshieldbutton.SetActive(false);
            }
        //}
    }

    public void Menu()
    {
        Debug.Log("clicked it");

    }
}
