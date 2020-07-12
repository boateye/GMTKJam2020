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
    [SerializeField]
    private GameObject chatUser;
    public void Awake()
    {

    }
    public void SetText(string textString)
    {
        myText.text = textString;
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
        SetText("message deleted");
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
    }
    /// <summary>
    /// This function warns the user, giving them a chance to redeem themselves.
    /// </summary>
    public void messageWarn()
    {
        GetComponent<Image>().color = Color.red;
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
    }
    /// <summary>
    /// This function bans the user from chat, disabling them from being able to chat in the future.
    /// </summary>
    public void messageBan()
    {
        // check popularity, if high bad points to scorekeeper
        // check message favorability, if low good points to scorekeeper
        GetComponent<Image>().color = Color.red;
        SetText(chatUser + " has been banned");
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
    }
}
