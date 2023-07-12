using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNarrador : MonoBehaviour
{
    WindowsVoice windowsVoice;
    public bool activeNarrador;
    public string textToSpeach;
    string text;
    // Start is called before the first frame update
    void Start()
    {
        windowsVoice = GetComponent<WindowsVoice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeNarrador)
        {
            if (text != textToSpeach)
            {
            text = textToSpeach;
            WindowsVoice.addToSpeechQueue(text);
             }
        }
        else
        {
            WindowsVoice.addToSpeechQueue("");
        }
    }
    public void Text(string newText)
    {
        textToSpeach = newText;
    }
}
