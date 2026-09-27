using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : AnimatedEntity // The NPC is also an AnimatedEntity, which is defined in AnimatedEntity.cs
{
    [SerializeField] TextMeshPro dialogue;
    [SerializeField] string npcName;
    
    [Header("Animation Settings")] 
    public List<Sprite> idle;

    void Start()
    {
        AnimationSetup();
        AnimationCycle = idle;
    }
    void Update()
    {
        AnimationUpdate();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            string[] lines = BarkSystem.Instance.GetDialogue(npcName, GameController.Instance.gameState);
            if(lines.Length > 0)
            {
                string line = lines[Random.Range(0, lines.Length)].ToString();

                // Removing the " ", if there is any
                if (line.StartsWith("\"") && line.EndsWith("\""))
                {
                    line = line.Substring(1, line.Length - 2);
                }

                dialogue.text = line;
            }
            else
            {
                Debug.Log("Class or State not Found!");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            dialogue.text = "";
        }
        
    }
}
