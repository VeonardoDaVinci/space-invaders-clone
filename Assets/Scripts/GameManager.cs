using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public int score = 0;
    private GameObject healthObject;
    [HideInInspector] public TextMeshProUGUI healthCount;
    private GameObject scoreObject;
    private TextMeshProUGUI scoreText;
    private GameObject messegeObject;
    private TextMeshProUGUI messegeText;
    private GameObject scoreSafeText;
    private GameObject player;
    [HideInInspector] public int enemyCount;
    public static bool win = false;
    private static int scoreSafe;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        healthObject = GameObject.FindGameObjectWithTag("Health");
        if (healthObject) healthCount = healthObject.GetComponent<TextMeshProUGUI>();

        messegeObject = GameObject.FindGameObjectWithTag("Messege");
        if (messegeObject) messegeText = messegeObject.GetComponent<TextMeshProUGUI>();
        
        
        scoreObject = GameObject.FindGameObjectWithTag("Score");
        if (scoreObject)  scoreText = scoreObject.GetComponent<TextMeshProUGUI>(); 

        scoreSafeText = GameObject.FindGameObjectWithTag("ScoreSafe");
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (scoreSafeText) scoreSafeText.GetComponent<TextMeshProUGUI>().text = scoreSafe.ToString();
    }

    public void LoadNextLevel()
    {
        scoreSafe = score;
        SceneManager.LoadScene("Game");
    }
    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene("GameOver");
        scoreSafe = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!player.activeSelf)
            {
                win = false;
                LoadNextLevel();
            }
            if (enemyCount == 0)
            {
                win = true;
                LoadNextLevel();
            }
        }

        if (scoreText)
        {
        scoreText.text = score.ToString();
        }

        if (messegeObject)
        {
            if (win)
            {
                messegeText.text = "You win!";
            }
            else
            {
                messegeText.text = "You lose!";
            }
        }
    }
}
