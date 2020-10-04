using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentencesToShow = new Queue<string>();
    private string lastMes;
    public static DialogueManager Instance;

    private void Start()
    {
        //Make sure it's only one (singleton)
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialogue(string[] dialogueText, string lastmessage)
    {
        _sentencesToShow.Clear();

        foreach (var text in dialogueText)
        {
            _sentencesToShow.Enqueue(text);
        }
        lastMes = lastmessage;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_sentencesToShow.Count == 0) 
        { 
            Debug.Log(lastMes); 
            EndOfDialogue(); 
        }

        //Todo Show some text on a dialogue bar
        Debug.Log(_sentencesToShow.Dequeue());
    }

    public void EndOfDialogue()
    {
        // Todo close a dialogue bar on the bottom part of the screen
    }
}
