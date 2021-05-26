using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addgold : MonoBehaviour
{
    // Start is called before the first frame update
    private bool setoff;

    void update(){
        if(setoff){
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Player")){
            Goldmanager.GoldAmount +=300;
            Debug.Log("I touch chest");
            setoff = true;
            this.gameObject.SetActive(false);
        }
    }
}
