using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIScript : MonoBehaviour
{
    public int score = 0;
    private GameObject scoreText;
    private GameObject messege;
    private GameObject scoreSafeText;
    private GameObject player;
    [HideInInspector] public int enemyCount;
    public static bool win = false;
    private static int scoreSafe;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        messege = GameObject.FindGameObjectWithTag("Messege");
        scoreSafeText = GameObject.FindGameObjectWithTag("ScoreSafe");
        scoreText = GameObject.FindGameObjectWithTag("Score");
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (scoreSafeText)
        {
            scoreSafeText.GetComponent<TextMeshProUGUI>().text = scoreSafe.ToString();
        }
    }

    public void LoadNextLevel()
    {
        scoreSafe = score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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



        //if(!GameObject.FindGameObjectWithTag("Player"))
        //{
        //    win = false;
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}

        if (scoreText)
        {
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
        }

        if (messege)
        {
            if (win)
            {
                messege.GetComponent<TextMeshProUGUI>().text = "You win!";
            }
            else
            {
                messege.GetComponent<TextMeshProUGUI>().text = "You lose!";
            }
        }
    }
}
