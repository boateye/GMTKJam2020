using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private const string PrefabName = "Score_Keeper";

    private static ScoreKeeper skInstance = null;

    /// <summary>
    /// Gets the instance of the ScoreKeeper.
    /// If one doesn't exist, instantiates a prefab and returns it.
    /// </summary>
    private static ScoreKeeper Instance
    {
        get
        {
            if (skInstance == null)
            { skInstance = Instantiate(Resources.Load<ScoreKeeper>(PrefabName)); }
            return skInstance;
        }
    }

    /// <summary>
    /// This increases when the player takes an action that is favorable to the streamers wishes.
    /// </summary>
    public static int GoodScore;
    /// <summary>
    /// This increases when the player takes an action that is against the streamers wishes.
    /// </summary>
    public static int BadScore;

    public static int CalculatedScore;
    /// <summary>
    /// Assigns this instance to singleton instance, stops it from getting destroyed and initalizes variables.
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(skInstance == null)
        { skInstance = this; }
        else
        {
            Destroy(gameObject);
        }
        

        // initialize scores
        GoodScore = 0;
        BadScore = 0; 
    }

    public static int CalculateScore()
    {
        int totalScore; 
        totalScore = GoodScore + BadScore;
        totalScore /= 2;
        return totalScore;
    }

}
