using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class NamesAndMessages : MonoBehaviour
{
    public ArrayList usernameList = new ArrayList();
    public ArrayList greetingsList = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        // iterate through each list of messages and add them to the appropriate arrays.
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
