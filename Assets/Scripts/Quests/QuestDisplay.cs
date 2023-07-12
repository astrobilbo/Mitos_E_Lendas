using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestDisplay : MonoBehaviour
{

    public Quest quest;
    TextMeshProUGUI textMeshPro;
    void Start()
    {
        textMeshPro = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        write();
    }
    public void write()
    {
        if (quest.isFinished)
        {
            textMeshPro.fontStyle = FontStyles.Strikethrough;
            textMeshPro.text = quest.questFeita;
        }else
        {
            textMeshPro.text = quest.quest;
        }
    }
    public void questFinished()
    {
        quest.isFinished=true;
    }
}
