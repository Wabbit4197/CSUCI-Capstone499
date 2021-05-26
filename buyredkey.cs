using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buyredkey : MonoBehaviour
{
    // Start is called before the first frame update
   public bool canbuy ;
   public GameObject RedKeyShop;
    
    void Start(){
        RedKeyShop.SetActive(false);
    }
    void Update()
    {
        if(canbuy){
            if(Input.GetKeyDown(KeyCode.Z) && Goldmanager.GoldAmount>=300){
                Keymanagerred.redkeyAmount+=1;
                Goldmanager.GoldAmount-=300;
                RedKeyShop.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            RedKeyShop.SetActive(true);
            canbuy = true;
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            RedKeyShop.SetActive(false);
            canbuy = false;
        }
    }
   

}
