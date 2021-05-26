using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class savegame 
{
   public static void SavePlayer( player player)
   {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream (path,FileMode.Create);

        playerdata data = new playerdata(player);

        formatter.Serialize(stream,data);
        stream.Close();
   }
    
    public static playerdata LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            playerdata data = formatter.Deserialize(stream) as playerdata;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("no save file is found in " + path);
            return null;
        }

    }
}
