using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScene(SaveControll saveControll)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameSave.MSav";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveScene data=new SaveScene(saveControll);
        formatter.Serialize(stream,data);
        stream.Close();
        
    }
    public static SaveScene LoadScene()
    {
        string path = Application.persistentDataPath + "/GameSave.MSav";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            SaveScene data= formatter.Deserialize(stream) as SaveScene;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
        
    }



       public static void SaveQuests(SaveControll saveControll)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/QuestsSave.MSav";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveInformation data=new SaveInformation(saveControll);
        formatter.Serialize(stream,data);
        stream.Close();
        
    }
    public static SaveInformation LoadQuest()
    {
        string path = Application.persistentDataPath + "/QuestsSave.MSav";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);
            SaveInformation data= formatter.Deserialize(stream) as SaveInformation;
            stream.Close();

            return data;

        }
        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
        
    }

}
