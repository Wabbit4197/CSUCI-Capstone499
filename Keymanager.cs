using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keymanager : MonoBehaviour
{
    Text yellowkeyText;
    public static int yellowkeyAmount;


    // Start is called before the first frame update
    void Start()
    {
       
        yellowkeyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        yellowkeyText.text = yellowkeyAmount.ToString();
    }
}
