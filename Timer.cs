using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    //start time value
    [SerializeField] float startTime;
    float currentTime;
    bool timerStarted = false;

    [SerializeField] TMP_Text timerText;

    private GameEnding gameEnding;
    public AudioSource gameOverAudio;
    public GameObject gameOverSFX;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 30;
        currentTime = startTime;
        timerText.text = currentTime.ToString();
        timerStarted = true;

        //gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            //subtracting previous frames duration
            currentTime -= Time.deltaTime;

            if(currentTime <= 0)
            {
                Debug.Log("Timer reached 0");
                timerStarted = false;
                currentTime = 0;

                //Game Over text on screen
                gameEnding = GameObject.Find("GameEnding").GetComponent<GameEnding>();
                gameEnding.GameOver();

                //play Game Over Audio
                gameOverSFX.SetActive(true);
                gameOverAudio.Play();
            }

            timerText.text = currentTime.ToString("f1");
        }
    }

    
}
