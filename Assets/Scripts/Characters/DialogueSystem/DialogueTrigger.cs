using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void StartDialogue(int id)
    {
        Dialogue.TextDialogue sentences = SentensesLoader.AllDialogues[id];
        DialogueManager.Instance.StartDialogue(sentences.Sentences, sentences.LastSentence);
    }
}
