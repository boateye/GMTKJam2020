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

    public void OnClick()
    {
        actionPopup.SetActive(true);
        actionPopup.GetComponent<ActionPopupController>().activeMessage = gameObject;
    }

    public void messageDelete()
    {
        SetText("message deleted");
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
    }

    public void messageWarn()
    {
        GetComponent<Image>().color = Color.red;
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
    }

    public void messageBan()
    {
        
        GetComponent<Image>().color = Color.red;
        SetText(chatUser + " has been banned");
        GetComponent<Button>().interactable = false;
        actionPopup.SetActive(false);
    }
}
