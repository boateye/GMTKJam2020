using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI myText;
    [SerializeField]
    private GameObject actionPopup;
    public GameObject chatUser;
    public List<AudioClip> SFX = new List<AudioClip>();
    public AudioSource audioSource;
    public string userName;
    public bool isMessageGood;

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void InitializeButtonText()
    {
        SetText(userName + ": " + chatUser.GetComponent<ChatUser>().ChooseRandomizedMessage());
        userName = chatUser.GetComponent<ChatUser>().userName;
        isMessageGood = chatUser.GetComponent<ChatUser>().isGood;
    }
    
    /// <summary>
    /// Called when the chat element is clicked
    /// </summary>
    public void OnClick()
    {
        actionPopup.SetActive(true);
        actionPopup.GetComponent<ActionPopupController>().activeMessage = gameObject;
    }
    /// <summary>
    /// deletes the users message from chat, replacing the message with "message deleted"
    /// </summary>
    public void messageDelete()
    {
        if (isMessageGood)
        {
            ScoreKeeper.GOODSCORE++;
        }
        else
        {
            ScoreKeeper.BADSCORE++;
        }
        SetText("message deleted");
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);

        audioSource = audioSource.GetComponent<AudioSource>();
        audioSource.PlayOneShot(SFX[1]);
        
    }
    /// <summary>
    /// This function warns the user, giving them a chance to redeem themselves.
    /// </summary>
    public void messageWarn()
    {
        if (isMessageGood)
        {
            ScoreKeeper.GOODSCORE++;
        }
        else
        {
            ScoreKeeper.BADSCORE++;
        }
        GetComponent<Image>().color = Color.red;
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
        audioSource.PlayOneShot(SFX[2]);
    }
    /// <summary>
    /// This function bans the user from chat, disabling them from being able to chat in the future.
    /// </summary>
    public void messageBan()
    {
        // check popularity, if high bad points to scorekeeper
        // check message favorability, if low good points to scorekeeper
        if(isMessageGood)
		{
            ScoreKeeper.GOODSCORE++;
		}
        else
		{
            ScoreKeeper.BADSCORE++;
		}
        GetComponent<Image>().color = Color.red;
        SetText(userName + ": has been banned");
        ScoreKeeper.DeleteNameFromList(userName);
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
        audioSource.PlayOneShot(SFX[0]);
    }
}
