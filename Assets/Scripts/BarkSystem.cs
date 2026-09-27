using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BarkSystem;

public class BarkSystem : MonoBehaviour
{
    public TextAsset BarkCSV;

    public static BarkSystem _instance;
    public static BarkSystem Instance { get { return _instance; } }

    [System.Serializable]
    public class BarkEntry
    {
        public string NPCName;
        public string State;
        public string Dialogue;
    }

    [System.Serializable]
    public class BarkEntryList
    {
        public BarkEntry[] entries;
    }

    private List<BarkEntry> barkList = new List<BarkEntry>();

    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ParseDialogueText();
    }


    void ParseDialogueText()
    {
        //Parse the CSV, split it into names, states, and text
        string[] lines = BarkCSV.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            string[] splitRow = lines[i].Split(',');

            if (splitRow.Length >= 1)
            {
                BarkEntry entry = new BarkEntry
                {
                    NPCName = splitRow[0].Trim(),
                    State = splitRow[1].Trim(),
                    Dialogue = string.Join(",", splitRow, 2, splitRow.Length - 2).Trim() // Joining rest of the splits
                };

                barkList.Add(entry);
            }
        }
    }

    public string[] GetDialogue(string npcName, string gameState)
    {
        List<string> dialogues = new List<string>();

        
        foreach (BarkEntry entry in barkList)
        {
            if (entry.NPCName == npcName && entry.State == gameState)//If this NPC has an entry for this state
            {
                dialogues.Add(entry.Dialogue);//Add it to the list of dialogues the NPC can say!
            }
        }
            
        

        return dialogues.ToArray();
    }
}
