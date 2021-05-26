using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class signNPC : MonoBehaviour
{
    
    public GameObject dialogBox;
    public TextMeshProUGUI dialoguetext;

    public string dialog;
    public bool dialogActive;

    public static bool playerinrange;

    public static int test;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerinrange)
        {
            print("hello world");
            print("check" + playerinrange);
            if(dialogBox.activeInHierarchy){
                dialogBox.SetActive(false);
            }

            else{
                print("Hello world2");
                dialogBox.SetActive(true);
                dialoguetext.text = dialog;

            }
        }
    }
    

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
                print("i touch you 3");
            
    }
    */

    void OnTriggerEnter2D(Collider2D collisions)
    {
            if (collisions.gameObject.CompareTag("Player"))
                print("i touch you ");
                playerinrange = true;
                test = 1;
                
    }

    void OnTriggerExit2D(Collider2D collisions)
    {
            if (collisions.gameObject.CompareTag("Player"))
                print("i am out");
                playerinrange = false;
    }

   
  

    
}

