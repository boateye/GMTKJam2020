using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonListButton : MonoBehaviour
{
    //[SerializeField]
    //private Text myText; 
    [SerializeField]
    private TextMeshProUGUI myText;
    [SerializeField]
    private GameObject actionPopup;
    public GameObject chatUser;
    public List<AudioClip> SFX = new List<AudioClip>();
    public AudioSource audioSource;

    public void SetText(string textString)
    {
        myText.text = textString;
    }

    public void InitializeButtonText()
    {
        SetText(chatUser.GetComponent<ChatUser>().userName + ": " + chatUser.GetComponent<ChatUser>().ChooseRandomizedMessage());
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
        if (chatUser.GetComponent<ChatUser>().isGood)
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
        if (chatUser.GetComponent<ChatUser>().isGood)
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
        if(chatUser.GetComponent<ChatUser>().isGood)
		{
            ScoreKeeper.GOODSCORE++;
		}
        else
		{
            ScoreKeeper.BADSCORE++;
		}
        GetComponent<Image>().color = Color.red;
        SetText(chatUser.GetComponent<ChatUser>().userName + ": has been banned");
        ScoreKeeper.DeleteNameFromList(chatUser.GetComponent<ChatUser>().userName);
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
        audioSource.PlayOneShot(SFX[0]);
    }
}
