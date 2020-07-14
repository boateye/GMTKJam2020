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
    public TextMeshProUGUI ViewerCountText;
    public SceneChanger sceneChanger;
    public float messageCooldown;
    /// <summary>
    /// Change this to make the wave more intense. The lower the number the greater the intensity
    /// </summary>
    public float waveSeverity = 1;
    private float currentCooldown;
    float resetCooldown;


    private IEnumerator Cooldown
	{
		get
		{
            //currentCooldown = 0;
            /*while (currentCooldown < messageCooldown)
			{
                currentCooldown += Time.deltaTime;
            }*/
            yield return new WaitForSeconds(messageCooldown);

			GameObject button = Instantiate(buttonTemplate) as GameObject;
			button.GetComponent<ButtonListButton>().chatUser.GetComponent<ChatUser>().ChooseRandomizedAttributes();
			button.GetComponent<ButtonListButton>().InitializeButtonText();
			button.SetActive(true);
			button.transform.SetParent(buttonTemplate.transform.parent, false);

			StartCoroutine(Cooldown);
            

            //yield return new WaitForEndOfFrame();
        }
	}

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(160);
        //yield return new WaitForSeconds(10);
        //Debug.Log("The video has ended!");

        //insert next scene script here
        sceneChanger.ChangeScene("ScoreScene");
    }

    /// <summary>
    /// Starts chat wave. 
    /// Use wait time to determine how many seconds into gameplay the wave starts.
    /// Use surge time to determine how long the surge lasts
    /// </summary>
    /// <param name="waitTime"></param>
    /// <param name="surgeTime"></param>
    /// <returns></returns>
    private IEnumerator StartWave(float waitTime, float surgeTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        StopCoroutine(Cooldown);
        messageCooldown = waveSeverity;
        StartCoroutine(Cooldown);
        yield return new WaitForSeconds(surgeTime);
        messageCooldown = resetCooldown;

    }



    private void Start()
    {
        resetCooldown = messageCooldown;
        StartCoroutine(EndGame());
        StartCoroutine(Cooldown);
        StartCoroutine(StartWave(33,5));
        StartCoroutine(StartWave(99,5));
        StartCoroutine(StartWave(122,5));
        StartCoroutine(StartWave(139,5));

    }
    public void CalculateViewCount()
    {
        int totalScore;
        totalScore = ScoreKeeper.GOODSCORE - ScoreKeeper.BADSCORE;
        if (totalScore < 0)
            totalScore = 0;
        ScoreKeeper.VIEWERCOUNT = totalScore * ScoreKeeper.viewerCountMultiplier;
        ViewerCountText.text = ScoreKeeper.VIEWERCOUNT.ToString();
    }
    void Update()
    {
        CalculateViewCount();
    }
}
