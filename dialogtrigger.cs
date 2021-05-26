using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogtrigger : MonoBehaviour {

	public Dialogue dialogue;

	public bool playerinrange;


    /*public void OntriggerEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Z))
        {
            playerinrange = true;
            print("sup");
        }

    }
    
    public void OntriggerExit2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("supper");
        }

    }
    */
    

    public void TriggerDialogue ()
	{
		FindObjectOfType<dialogmanager>().StartDialogue(dialogue);
        
	}

}