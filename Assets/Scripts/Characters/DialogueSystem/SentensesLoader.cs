
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SentensesLoader : MonoBehaviour
{
    Dialogue dialogue = new Dialogue(new string[] { "First sentence", "Second sentence", "Last one before looping one" }, "Looping sentence");
    public static Dictionary<int, Dialogue.TextDialogue> AllDialogues = new Dictionary<int, Dialogue.TextDialogue>();
    public static SentensesLoader Instance;
    public bool isLoaded = false;
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


        string filename = "DialoguePool.xml";
        if(isLoaded == false)
            DeserializeAndStore(filename);

    }

    private void DeserializeAndStore(string filename)
    {
        XmlSerializer xmlFormat = new XmlSerializer(typeof(Dialogue[]));

        using (Stream fStream = new FileStream(filename,
        FileMode.Open, FileAccess.Read, FileShare.None))
        {
            Dialogue[] newLines = (Dialogue[])xmlFormat.Deserialize(fStream);
            foreach (var item in newLines)
            {
                AllDialogues.Add(item.ObjectID, item.textdial);
            }
        }
        isLoaded = true;
    }

    // Serializer
    private void SaveInXmlFormat(object objGraph, string fileName)
    {
        XmlSerializer xmlFormat = new XmlSerializer(typeof(Dialogue[]));
        using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
        {
            xmlFormat.Serialize(fStream, objGraph);
        }
    }
}
