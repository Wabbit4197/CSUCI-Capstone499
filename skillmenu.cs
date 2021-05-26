using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillmenu : MonoBehaviour
{
    // Start is called before the first frame update
    Text skilllist;
    
    // Start is called before the first frame update
    void Start()
    {
        skilllist = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.canfireball){
            skilllist.text = "Fireball";
        }

        else{
            skilllist.text = "N/A";
        }
    }
    
}
