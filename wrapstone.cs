using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wrapstone : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public static bool canTP;
    void Update()
    {
        if(canTP &&Input.GetKeyDown(KeyCode.Alpha0)){
            SceneManager.LoadScene("town");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("wrapstone")){
            canTP = true;
            Debug.Log("I touch it");
            other.gameObject.SetActive(false);
        }
    }
}
