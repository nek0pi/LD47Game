using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    bool isFirstTime = true;
    public void StartDialogue(int id)
    {
        Dialogue.TextDialogue sentences = SentensesLoader.AllDialogues[id];
        if (isFirstTime)
        {
            DialogueManager.Instance.StartDialogue(sentences.Sentences, sentences.LastSentence);
            isFirstTime = false;
        }
        else
        {
            DialogueManager.Instance.DisplayNextSentence();
        }
    }
}
