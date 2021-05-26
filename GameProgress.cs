 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using System.IO;
 using System.Runtime.Serialization.Formatters.Binary;
 using System.Xml;
 using System.Xml.Serialization;
 
 [System.Serializable]
 public class MyItem
 {
     // You can store here what you want.
     public Vector3 Position;
 }
 
 [System.Serializable]
 public class MyItemDatabase
 {
     // We need to store more then one class.
     // And because of this we need to convert our "MyItem" class into "List<>".
     [XmlArray("Items")]
     public List<MyItem> myItem;
 }
 
 public class GameProgress : MonoBehaviour
 {
     // Your item object.
     public GameObject itemObject;
 
     // To save, load and remove each Level progress into different XML files using unique ID for it.
     // You need give "ID" to each level.
     public int ID;
 
     // We need to reach to "MyItemDatabase" class from "GameItem" script.
     public MyItemDatabase myItemDatabase;
 
     private void Start()
     {
         // Load file.
         if (System.IO.File.Exists(Application.dataPath + "/StreamingAssets/Level.xml" + ID))
         {
             Load();
 
             for (int i = 0; i < myItemDatabase.myItem.Count; i++)
             {
                 // If (Player did not take some item objects) there are item objects in the XML file then we need to spawn our item objects into scene.
                 // We take our position of our item objects and take that item objects into scene back.
                 Instantiate(itemObject, myItemDatabase.myItem[i].Position, Quaternion.identity);
             }
         }
     }
 
     private void Update()
     {
         Save();
     }
 
     private void Load()
     {
         // We check is there XML file exists or not before we load it.
         if (System.IO.File.Exists(Application.dataPath + "/StreamingAssets/Level.xml" + ID))
         {
             // If is there XML file then we load it.
             XmlSerializer XmlSerializer = new XmlSerializer(typeof(MyItemDatabase));
             FileStream FileStream = new FileStream(Application.dataPath + "/StreamingAssets/Level.xml" + ID, FileMode.Open);
             myItemDatabase = XmlSerializer.Deserialize(FileStream) as MyItemDatabase;
             FileStream.Close();
         }
     }
 
     public void Save()
     {
         // We save our progress.
         XmlSerializer XmlSerializer = new XmlSerializer(typeof(MyItemDatabase));
         FileStream FileStream = new FileStream(Application.dataPath + "/StreamingAssets/Level.xml" + ID, FileMode.Create);
         XmlSerializer.Serialize(FileStream, myItemDatabase);
         FileStream.Close();
     }
 }