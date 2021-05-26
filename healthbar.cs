using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    Text healthText;
    public static int healthpointAmount;
    public static int maxhealthpointAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthpointAmount = player.healthvalue;
        maxhealthpointAmount = player.maxhp;
        
        healthText.text = healthpointAmount.ToString("0") + "/" + maxhealthpointAmount.ToString("0");
    }
    
}