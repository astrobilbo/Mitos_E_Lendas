using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveControll : MonoBehaviour
{
    public static SaveControll instance;
    bool isLoad = false;
    public Quest[] quest;
    public bool[] boolQuest;


    public void Awake()
    {

        LoadQuest();
    }

    private void LoadQuest()
    {
        //quest=new Quest[7];
        boolQuest=new bool[7];
        for (int i = 0; i < quest.Length; i++)
        {
            if (!isLoad)
            {
                boolQuest[i] = quest[i].isFinished;
            }
            else
            {
                SaveInformation data = SaveSystem.LoadQuest();
                boolQuest[i] = data.finishedDialogue[i];
                quest[i].isFinished = boolQuest[i];
            }
            
        }
    }

    public int ActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void SaveScene()
    {
        SaveSystem.SaveScene(this);
        SaveSystem.SaveQuests(this);
    }
    public void LoadScene()
    {
        SaveScene data = SaveSystem.LoadScene();
        if (data == null) return;
        SceneManager.LoadScene(data.actualScene);
        isLoad = true;
        LoadQuest();
    }

}
