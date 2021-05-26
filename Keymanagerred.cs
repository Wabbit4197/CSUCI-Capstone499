using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keymanagerred : MonoBehaviour
{
    Text redkeyText;
    public static int redkeyAmount;


    // Start is called before the first frame update
    void Start()
    {
       
        redkeyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        redkeyText.text = redkeyAmount.ToString();
    }
}
