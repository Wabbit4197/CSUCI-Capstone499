using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goldmanager : MonoBehaviour
{
    Text GoldText;
    public static int GoldAmount = 100;


    // Start is called before the first frame update
    void Start()
    {
       
        GoldText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = GoldAmount.ToString();
    }
}