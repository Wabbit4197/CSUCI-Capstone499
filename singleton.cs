using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class singleton : MonoBehaviour
{
    // Start is called before the first frame update
    public static singleton Instance;

    public bool checkenemybool;

    public player player;

    [SerializeField] public static List<GameObject> list1= new List<GameObject>();
    void Awake()
     {
         if (Instance == null)
         {
             DontDestroyOnLoad(gameObject);
             Instance = this;
         }
         else if (Instance != this)
         {
             Destroy(gameObject);
             
         }
         
     }

    
     void Start()
     {
          foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
            {     
                //obj.CompareTag("canbepickup")||
                if(obj.CompareTag("enemy")){
                    Debug.Log(obj.name);
                    Debug.Log("Im here");
                    list1.Add(obj);
                }
            }
     }

     
     void Update()
     {
       
    }
     
}

     
     
     
     

