using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;
    [SerializeField]
    private GameObject userTemplate;
    public float messageCooldown;
    /// <summary>
    /// Change this to make the wave more intense. The lower the number the greater the intensity
    /// </summary>
    public float waveSeverity = 1;
    private float currentCooldown;
    public string testMessage;
    float resetCooldown;
    private string chatMessages;
    TextMeshProUGUI chatWindow;
    public ArrayList chatBus = new ArrayList();

 ;
    private IEnumerator Cooldown
	{
		get
		{
			currentCooldown = 0;

            yield return new WaitForSeconds(messageCooldown);

			GameObject button = Instantiate(buttonTemplate) as GameObject;
			button.GetComponent<ButtonListButton>().chatUser.GetComponent<ChatUser>().ChooseRandomizedAttributes();
			button.GetComponent<ButtonListButton>().InitializeButtonText();
			button.SetActive(true);
			button.transform.SetParent(buttonTemplate.transform.parent, false);

			StartCoroutine(Cooldown);

		}
	}

	private void Start()
    {
        waveSeverity = 3;
        resetCooldown = messageCooldown;
        StartCoroutine(Cooldown);

        waveSeverity = 3; 

        //InitialCoroutine = StartWave(1,32);
        //FirstWaveCoroutine = StartWave(33,5);
        //SecondWaveCoroutine = StartWave(99,5);
        //ThirdWaveCoroutine = StartWave(122,5);
        //ForthWaveCoroutine = StartWave(139,5);
    

    }

    private void Update()
    {
        /*if (messageCooldown > 0)    
        {
            messageCooldown -= Time.deltaTime;
        }

        else if (messageCooldown <= 0)
        {
            // Displays message once cooldown hits/goes below 0 then resets cooldown

         
            
            // spawns button with randomized message
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.GetComponent<ButtonListButton>().chatUser.GetComponent<ChatUser>().ChooseRandomizedAttributes();
            button.GetComponent<ButtonListButton>().InitializeButtonText();
            button.SetActive(true);
            button.transform.SetParent(buttonTemplate.transform.parent, false);

            //chatWindow.text = chatMessages;
            messageCooldown = resetCooldown;
        }*/
    }
 

    /// <summary>
    /// Starts chat wave. 
    /// Use wait time to determine how many seconds into gameplay the wave starts.
    /// Use surge time to determine how long the surge lasts
    /// </summary>
    /// <param name="waitTime"></param>
    /// <param name="surgeTime"></param>
    /// <returns></returns>
    private IEnumerator StartWave(float waitTime,float surgeTime)
    {
        yield return new WaitForSeconds(waitTime);
        messageCooldown = waveSeverity;
        yield return new WaitForSeconds(surgeTime);
        messageCooldown = resetCooldown;
    }

}
