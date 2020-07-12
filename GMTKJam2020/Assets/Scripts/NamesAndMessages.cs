using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class NamesAndMessages : MonoBehaviour
{
    public ArrayList usernameList = new ArrayList();
    public ArrayList beliefList = new ArrayList();
    public ArrayList chatcommandsList = new ArrayList();
    public ArrayList disbeliefList = new ArrayList();
    public ArrayList emoticonsList = new ArrayList();
    public ArrayList genericList = new ArrayList();
    public ArrayList greetingsList = new ArrayList();
    public ArrayList hashtagsList = new ArrayList();
    public ArrayList linksList = new ArrayList();
    public ArrayList spamlinksList = new ArrayList();


    // Start is called before the first frame update
    void Start()
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

    public void DeleteFromList(string nameToDelete)
	{

	}

    public void AddNameToList(string nameToAdd)
	{

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
