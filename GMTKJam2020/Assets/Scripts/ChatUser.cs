using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatUser : MonoBehaviour
{
    public string userName;
    public float messageInterval;
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

    public RelationshipID relationshipID;
    public PersonalityID personalityID;
    public UserTypeID userTypeID;

    // Start is called before the first frame update
    public void Start()
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
        //remainingUsernameCount = namesAndMessages.GetComponent<NamesAndMessages>().usernameList.Count;
        //selectedUsernameIndex = Random.Range(0, remainingUsernameCount);
        //userName = namesAndMessages.GetComponent<NamesAndMessages>().usernameList[selectedUsernameIndex].ToString();
        //namesAndMessages.GetComponent<NamesAndMessages>().usernameList.RemoveAt(selectedUsernameIndex);
        //Debug.Log("My username is: " + userName + " and i am the " + relationshipID + " " + userTypeID + " " + personalityID);
    }

    // Update is called once per frame
    void Update()
    {
        if (messageInterval > 0)
        {
            messageInterval -= Time.deltaTime;
        }

        else if (messageInterval <= 0)
        {
            // Displays message once cooldown hits/goes below 0 then resets cooldown

            string testMessage = namesAndMessages.GetComponent<NamesAndMessages>().greetingsList[0].ToString();
            
            buttonListControl.GetComponent<ButtonListControl>().ch
            chatBus.Add(testMessage);
            foreach (string newMessage in chatBus)
            {

                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                button.GetComponent<ButtonListButton>().SetText(newMessage);

                button.transform.SetParent(buttonTemplate.transform.parent, false);
            }
            chatBus.Clear();
            //chatWindow.text = chatMessages;
            messageInterval = resetCooldown;
            //Debug.Log(resetCooldown);
        }
    }
}
