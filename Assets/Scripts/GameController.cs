using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Singleton pattern
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    //Game state is a collection of global macro-scale game state changes.
    public Dictionary<string, bool> gameState { get; private set; } // Defined like this to hide in inspector
    
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;

        gameState = new Dictionary<string, bool>(); //Initialize gameState
        //'flagTaken' is a global game state variable that starts false
        gameState.Add("flagNotTaken", true);//Starting game state
        gameState.Add("flagTaken", false);
        //Other game state variables could be added in the same way here
    }
}