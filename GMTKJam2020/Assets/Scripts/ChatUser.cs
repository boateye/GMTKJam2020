using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUser : MonoBehaviour
{
    public string userName;
    public float messageInterval;
    private float resetInterval;
    [SerializeField]
    public GameObject namesAndMessages;
    [SerializeField]
    public GameObject buttonListControl;
    private int remainingUsernameCount;
    private int selectedUsernameIndex;
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
        Self_Police,
        Troll
    }

    public enum UserTypeID
    {
        Mod,
        Sub,
        Follower,
        Viewer
    }

    public enum MessageTypeID
	{
        Belief,
        Command,
        Disbelief,
        Emoticon,
        Generic,
        Greetings,
        Hashtags,
        Links,
        SpamLinks
	}

    public RelationshipID relationshipID;
    public PersonalityID personalityID;
    public UserTypeID userTypeID;
    public MessageTypeID messageTypeID;
    public bool isGood = false;

    public string ChooseRandomizedMessage()
    {
        int r = Random.Range(2, 10);
        string messageToSend;
        switch (r)
        {

            case 2:
                messageToSend = ScoreKeeper.beliefList[Random.Range(0, ScoreKeeper.beliefList.Count)].ToString();
                messageTypeID = MessageTypeID.Belief;
                isGood = false;
                return messageToSend;
            case 3:
                messageToSend = ScoreKeeper.chatcommandsList[Random.Range(0, ScoreKeeper.chatcommandsList.Count)].ToString();
                messageTypeID = MessageTypeID.Command;
                return messageToSend;
            case 4:
                messageToSend = ScoreKeeper.disbeliefList[Random.Range(0, ScoreKeeper.disbeliefList.Count)].ToString();
                messageTypeID = MessageTypeID.Disbelief;
                isGood = true;
                return messageToSend;
            case 5:
                messageToSend = ScoreKeeper.emoticonsList[Random.Range(0, ScoreKeeper.emoticonsList.Count)].ToString();
                messageTypeID = MessageTypeID.Emoticon;
                return messageToSend;
            case 6:
                messageToSend = ScoreKeeper.genericList[Random.Range(0, ScoreKeeper.genericList.Count)].ToString();
                messageTypeID = MessageTypeID.Generic;
                isGood = false;
                return messageToSend;
            case 7:
                messageToSend = ScoreKeeper.greetingsList[Random.Range(0, ScoreKeeper.greetingsList.Count)].ToString();
                messageTypeID = MessageTypeID.Greetings;
                isGood = false;
                return messageToSend;
            case 8:
                messageToSend = ScoreKeeper.hashtagsList[Random.Range(0, ScoreKeeper.hashtagsList.Count)].ToString();
                messageTypeID = MessageTypeID.Hashtags;
                return messageToSend;
            case 9:
                messageToSend = ScoreKeeper.linksList[Random.Range(0, ScoreKeeper.linksList.Count)].ToString();
                messageTypeID = MessageTypeID.Links;
                isGood = false;
                return messageToSend;
            case 10:
                messageToSend = ScoreKeeper.spamlinksList[Random.Range(0, ScoreKeeper.spamlinksList.Count)].ToString();
                messageTypeID = MessageTypeID.SpamLinks;
                isGood = true;
                return messageToSend;
            default:
                Debug.Log("no message found. check RandomMessage()");
                break;
        }

        return "no message found. check RandomMessage()";
    }

    // Start is called before the first frame update
    public void ChooseRandomizedAttributes()
    {
        int t = Random.Range(1, 4);
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

        int r = Random.Range(1, 3);
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

        int p = Random.Range(1, 5);
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
            case 6:
                personalityID = PersonalityID.Troll;
                break;
        }

        // 'Rolls' on the screenname list and assigns it to this instance of the gameobject, then removes that name from the list.
        remainingUsernameCount = ScoreKeeper.usernameList.Count;
        selectedUsernameIndex = Random.Range(0, remainingUsernameCount);
        userName = ScoreKeeper.usernameList[selectedUsernameIndex].ToString();
        //ScoreKeeper.usernameList.RemoveAt(selectedUsernameIndex);
        //Debug.Log("My username is: " + userName + " and i am the " + relationshipID + " " + userTypeID + " " + personalityID);
    }
    
    
}
