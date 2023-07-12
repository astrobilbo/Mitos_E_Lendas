using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveInformation
{
    public bool[] finishedDialogue;

    public SaveInformation(SaveControll SaveControll)
    {
        finishedDialogue = new bool[7];
        finishedDialogue[0]=SaveControll.boolQuest[0];
        finishedDialogue[1]=SaveControll.boolQuest[1];
        finishedDialogue[2]=SaveControll.boolQuest[2];
        finishedDialogue[3]=SaveControll.boolQuest[3];
        finishedDialogue[4]=SaveControll.boolQuest[4];
        finishedDialogue[5]=SaveControll.boolQuest[5];
        finishedDialogue[6]=SaveControll.boolQuest[6];
    }
}
[System.Serializable]
public class SaveScene
{
    public int actualScene;
      public SaveScene(SaveControll SaveControll)
    {
        actualScene = SaveControll.ActiveScene();
        actualScene = SaveControll.ActiveScene();
    }
}
