using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public static class SaveSystem
{

    public static void SaveGame(LevelManager levelManager, EnemySpawner enemySpawner)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "D:/FPT/SE1604/FA23/PRU221m/Projects/My project" + "/game.fun";
        //string path = Application.persistentDataPath + "/game.fun";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(levelManager, enemySpawner);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadScore()
    {
        string path = "D:/FPT/SE1604/FA23/PRU221m/Projects/My project" + "/game.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}

