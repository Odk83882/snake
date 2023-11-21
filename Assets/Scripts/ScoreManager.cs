using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public float timeValue;
    //public Text timeText;
    public TMP_Text timeText;

    [SerializeField]
    private playermovement playermovement;


   public static ScoreManager instance;

   public Text scoreText;
   public Text highscoreText;


   int score = 0;
   int highscore = 0;


    private void Awake() {
        if (instance == null){
        instance = this;
        }
        
        else Destroy(gameObject);
    }

    void Update()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE :" + highscore.ToString();

       TimeChecker();
       DisplayTime(timeValue);
    }

    // Update is called once per frame
    public void AddPoint() {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    public void resetScore() {
       score = 0;
    }

    private void TimeChecker()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        if(timeValue <= 0)
        {
            playermovement.ResetState();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
