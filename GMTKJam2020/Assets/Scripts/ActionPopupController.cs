using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPopupController : MonoBehaviour
{
    public GameObject activeMessage = null;
    public ButtonListButton messageComponent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActionDelete()
    {
        activeMessage.GetComponent<ButtonListButton>().messageDelete();
    }

    public void ActionWarn()
    {
        activeMessage.GetComponent<ButtonListButton>().messageWarn();
    }

    public void ActionBan()
    {
        activeMessage.GetComponent<ButtonListButton>().messageBan();
    }
}
