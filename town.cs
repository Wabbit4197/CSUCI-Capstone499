using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class town : MonoBehaviour
{
    public bool gotown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gotown){
            SceneManager.LoadScene("town");
            gotown = false;
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        if( other.CompareTag("Player")){
            gotown = true;
            
            Debug.Log("Player touch me");
           
        }
    }

}
