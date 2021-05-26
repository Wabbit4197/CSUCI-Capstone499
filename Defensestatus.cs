using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defensestatus : MonoBehaviour
{
    // Start is called before the first frame update
    Text DefenseText;
    public static int playerdefense;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DefenseText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerdefense = player.defensevalue;
        DefenseText.text = playerdefense.ToString("0");
    }
}
