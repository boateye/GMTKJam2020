using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;
    public float messageCooldown;
    public string testMessage;
    float resetCooldown;
    private string chatMessages;
    TextMeshProUGUI chatWindow;
    ArrayList chatBus = new ArrayList();

    private void Start()
    {
        resetCooldown = messageCooldown;
        //chatWindow = GetComponent<TextMeshProUGUI>();
        chatMessages = "Welcome to my chat room!";
        //chatWindow.text = chatMessages;
        Debug.Log(resetCooldown);
    }

    private void Update()
    {
        if (messageCooldown > 0)
        {
            messageCooldown -= Time.deltaTime;
        }

        else if (messageCooldown <= 0)
        {
            // Displays message once cooldown hits/goes below 0 then resets cooldown

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
            messageCooldown = resetCooldown;
            Debug.Log(resetCooldown);
        }
    }
}
