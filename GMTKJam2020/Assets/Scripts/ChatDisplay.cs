using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ChatDisplay : MonoBehaviour
{
    // Declare chat message variables
    public float messageCooldown;
    public string testMessage;
    float resetCooldown;
    private string chatMessages;
    TextMeshProUGUI chatWindow;
    ArrayList chatBus = new ArrayList();
    ArrayList banlist = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        resetCooldown = messageCooldown;
        chatWindow = GetComponent<TextMeshProUGUI>();
        chatMessages = "Welcome to my chat room!";
        chatWindow.text = chatMessages;
        Debug.Log(resetCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        if (messageCooldown > 0)
        {
            messageCooldown -= Time.deltaTime;
        }
        
        else if (messageCooldown <= 0)
        {
            chatBus.Add(testMessage);
            foreach (string newMessage in chatBus)
            {
                chatMessages = chatMessages + "\n" + newMessage;
            }
            chatBus.Clear();
            chatWindow.text = chatMessages;
            messageCooldown = resetCooldown;
            Debug.Log(resetCooldown);
            //displays message once cooldown hits/goes below 0 then resets cooldown


            //foreach (string obj in chatBus)
            //{
            //    Debug.Log(obj);
            //    string appendmessage = obj;
            //    chatWindow.SetText("{0} {1}");
            //    chatWindow.text = appendmessage;
            //}


        }
    }
}
