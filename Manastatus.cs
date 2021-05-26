using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manastatus : MonoBehaviour
{
    // Start is called before the first frame update
    Text ManaText;



    // Start is called before the first frame update
    void Start()
    {
       
        ManaText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ManaText.text = player.manavalue.ToString();
        Debug.Log("mana is" + player.manavalue);
    }
}
