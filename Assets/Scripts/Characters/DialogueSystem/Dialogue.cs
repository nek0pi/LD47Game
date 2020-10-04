using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
public class Dialogue
{
    [XmlElement("ObjectID")]
    public int ObjectID { get; set; }
    public struct TextDialogue
    {
        [XmlElement("LastSentence")]
        public string LastSentence { get; set; }

        [XmlElement("Sentences")]
        public string[] Sentences { get; set; }
    }
    public TextDialogue textdial;
    public Dialogue() { }
    public Dialogue(string[] sent, string lsent) 
    {
        textdial.LastSentence = lsent;
        textdial.Sentences = sent;
    }


}
