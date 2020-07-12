using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUser : MonoBehaviour
{
    public string userName;
    public float messageInterval;

    public enum RelationshipID
    {
        Enemy,
        Rando,
        Friendly
    }

    public enum PersonalityID
    {
        SpamBot,
        Simp,
        Hater,
        Debater,
        Self_Police
    }

    public enum UserTypeID
    {
        Mod,
        Sub,
        Follower,
        Viewer
    }

    public RelationshipID relationshipID;
    public PersonalityID personalityID;
    public UserTypeID userTypeID;

    // Start is called before the first frame update
    public void Awaken()
    {
        int t = Random.Range(1,4);
        switch (t)
        {
            case 1:
                userTypeID = UserTypeID.Mod;
                break;
            case 2:
                userTypeID = UserTypeID.Sub;
                break;
            case 3:
                userTypeID = UserTypeID.Follower;
                break;
            case 4:
                userTypeID = UserTypeID.Viewer;
                break;
        }

        int r = Random.Range(1,3);
        switch (r)
        {
            case 1:
                relationshipID = RelationshipID.Enemy;
                break;
            case 2:
                relationshipID = RelationshipID.Rando;
                break;
            case 3:
                relationshipID = RelationshipID.Friendly;
                break;
        }

        int p = Random.Range(1,5);
        switch (p)
        {
            case 1:
                personalityID = PersonalityID.SpamBot;
                break;
            case 2:
                personalityID = PersonalityID.Simp;
                break;
            case 3:
                personalityID = PersonalityID.Hater;
                break;
            case 4:
                personalityID = PersonalityID.Debater;
                break;
            case 5:
                personalityID = PersonalityID.Self_Police;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
