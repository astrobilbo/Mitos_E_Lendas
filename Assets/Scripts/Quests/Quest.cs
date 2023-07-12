using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest",menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string quest;
    public string questFeita;
    public bool isFinished; 
    
}
