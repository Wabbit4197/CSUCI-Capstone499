using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class SpawnedGameItem : MonoBehaviour
 {
     // We find GameProgress gameobject and it into "gameProgress".
     public GameProgress gameProgress;
 
     // We take "MyItem" class to add our data from here.
     public MyItem myItem;
 
     // We need to check is it destroyed or not.
     public bool destroy;
 
     void Start()
     {
         // It's automatically finds and gets script of that gameobject.
         // Be sure add Tag into GameProgress gameobject and call that Tag as "GameProgress".
         gameProgress = GameObject.FindGameObjectWithTag("GameProgress").GetComponent<GameProgress>();
     }
 
     private void Update()
     {
         // You need to set true for "destroy" bool variable when you need to remove item from scene and saved file.
         // When the "destroy" is true then it will destroy and remove from saved XML file.
         // And it will not appear there when you reload the scene.
         if (destroy)
         {
             // We remove our item from "MyItemDatabase" class using "Remove(myItem)".
             gameProgress.myItemDatabase.myItem.Remove(myItem);
 
             // Then we need to update our saved file.
             // And we save it again.
             gameProgress.Save();
 
             // Destroy our game object from scene.
             Destroy(gameObject);
         }
     }
 }