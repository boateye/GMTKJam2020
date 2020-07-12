using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class ScoreKeeper : MonoBehaviour
{
    private const string PrefabName = "Score_Keeper";

    private static ScoreKeeper skInstance = null;
    public TextMeshProUGUI ViewerCountText;

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

    public static ArrayList usernameList = new ArrayList();
    public static ArrayList beliefList = new ArrayList();
    public static ArrayList chatcommandsList = new ArrayList();
    public static ArrayList disbeliefList = new ArrayList();
    public static ArrayList emoticonsList = new ArrayList();
    public static ArrayList genericList = new ArrayList();
    public static ArrayList greetingsList = new ArrayList();
    public static ArrayList hashtagsList = new ArrayList();
    public static ArrayList linksList = new ArrayList();
    public static ArrayList spamlinksList = new ArrayList();

    /// <summary>
    /// This determines by how much the base score is multiplied by to display the viewer count
    /// </summary>
    [SerializeField]
    private static int viewerCountMultiplier = 43;
    
    /// <summary>
    /// This increases when the player takes an action that is favorable to the streamers wishes.
    /// </summary>
    public static int GOODSCORE;
    
    /// <summary>
    /// This increases when the player takes an action that is against the streamers wishes.
    /// </summary>
    public static int BADSCORE;
    
    /// <summary>
    /// Keeps track of the view count to be displayed to the player
    /// </summary>
    public static int VIEWERCOUNT = 2020;
    
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
        GOODSCORE = 13;
        BADSCORE = 0;

        PopulateLists();
    }

    // Start is called before the first frame update
    void PopulateLists()
    {
        // iterate through each list of messages and add them to the appropriate arrays.
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/belief.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    beliefList.Add(line);
                    Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/chatcommands.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    chatcommandsList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/disbelief.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    disbeliefList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/emoticons.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    emoticonsList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/generic.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    genericList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/greetings.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    greetingsList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/hashtags.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    hashtagsList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/links.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    linksList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/spamlinks.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    spamlinksList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }

        // iterate through the list of screennames and add them to usernameList
        try
        {
            // Create an instance of StreamReader to read from a file.
            using (StreamReader sr = new StreamReader("Assets/Lists/screennames.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    usernameList.Add(line);
                    //Debug.Log(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("This file could not be read:" + e.Message);
        }
    }

    public void CalculateViewCount()
    {
        int totalScore;
        totalScore = GOODSCORE - BADSCORE;
        if (totalScore < 0)
            totalScore = 0;
        VIEWERCOUNT = totalScore * viewerCountMultiplier;
        ViewerCountText.text = VIEWERCOUNT.ToString();
    }

    /// <summary>
    /// This function can be improved in the future. Currently, its only use is to delete names when a user is banned.
    /// </summary>
    /// <param name="nameToDelete"></param>
    public static void DeleteNameFromList(string nameToDelete)
    {
        usernameList.Remove(nameToDelete);
    }

    public void AddNameToList(string nameToAdd)
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateViewCount();
    }
}
