﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inn : MonoBehaviour
{
    // Start is called before the first frame update

    public bool enter = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enter)
        {
            SceneManager.LoadScene("INN");
        }    
    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            enter = true;
        }
    }
}
