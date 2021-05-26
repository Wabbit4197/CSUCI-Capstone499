using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teleportlocation;
   
    private bool cantp;
    void start(){
        teleportlocation.SetActive(false);
    }
    void Update()
    {
        if(cantp){
            if(Input.GetKeyDown(KeyCode.Z) &&player.cantp5==true){
                SceneManager.LoadScene("floor005");
            }

            if(Input.GetKeyDown(KeyCode.X)&& player.cantp10==true){
                SceneManager.LoadScene("floor010");
            }

            if(Input.GetKeyDown(KeyCode.C)&& player.cantp15==true){
                SceneManager.LoadScene("floor15");
            }
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            teleportlocation.SetActive(true);
            cantp = true;
        }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            teleportlocation.SetActive(false);
            cantp = false;
        }
    }
}
