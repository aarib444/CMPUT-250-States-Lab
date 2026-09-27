using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Singleton pattern
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    //Game state is a collection of global macro-scale game state changes.
    public string gameState;
    
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;

        gameState = "flagNotTaken";
    }
}