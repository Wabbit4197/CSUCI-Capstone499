using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keymanagerblue : MonoBehaviour
{
    Text bluekeyText;
    public static int bluekeyAmount;


    // Start is called before the first frame update
    void Start()
    {
       
        bluekeyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bluekeyText.text = bluekeyAmount.ToString();
    }
}
