using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class destroyonload : MonoBehaviour
{
    // Start is called before the first frame update
    public static destroyonload instance;

    public static List<GameObject> mylist = new List<GameObject>();
    [SerializeField] public static List<GameObject> list1= new List<GameObject>();
    public static List<bool> boollist = new List<bool>();
    public static List<GameObject> itemlist;
    
    public Enemy enemy;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        }

         else
        {
          //Duplicate GameManager created every time the scene is loaded
          
          Destroy(gameObject);
        }       
        
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
            {     
                //obj.CompareTag("canbepickup")||
                if(obj.CompareTag("enemy")){
                    Debug.Log(obj.name);
                    Debug.Log("Im here");
                    list1.Add(obj);
                    //if(obj.GetComponent<Enemy>().shoulddestroy ==true){
                        //if(obj.GetComponent<Enemy>().shoulddestroy ==false){
                        if(enemy.shoulddestroy == false){
                        Debug.Log("First time encounter" + obj);
                        boollist.Add(false);
                    }

                    else{
                        Debug.Log("the hit object should be destory" + obj);
                        boollist.Add(true);
                    }
                    
                }
            }
        //itemlist.AddRange(list1);
    }

    void Start()
    {

        //for (var i = 0; i < list1.Count; i++) {
          //       Destroy(list1[i]);
          //}
        
        foreach(GameObject list in list1){
                Debug.Log("attempt to destory list" + list);
                if(list.activeInHierarchy &&enemy.shoulddestroy){
                list.SetActive(false);
                Debug.Log("attempt to set active false");
                }
        }

        /*if(itemlist!= null)
        {
            foreach(GameObject list in mylist){
                Debug.Log("attempt to destory list" + list);

                if(list.activeInHierarchy){
                list.SetActive(false);
                Debug.Log("attempt to set active false");
                }

                Debug.Log("done destory");
            }
            
            int i = 0;
            while(itemlist[i]!= null){

                    int j =0;
                    for(j=i;j<itemlist.Count;j++)
                    {
                        if(boollist[j] ==true){
                            Destroy(itemlist[i]);
                        }
                    }
                    i=i+1;
            }
            
                
            
        }
        */
        
        
    }
}
