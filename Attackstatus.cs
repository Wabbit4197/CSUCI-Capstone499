using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attackstatus : MonoBehaviour
{
    // Start is called before the first frame update
    Text attackText;
    public static int playerattack;
    
    
    // Start is called before the first frame update
    void Start()
    {
        attackText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerattack = player.attackvalue;
        attackText.text = playerattack.ToString("0");
    }
}
