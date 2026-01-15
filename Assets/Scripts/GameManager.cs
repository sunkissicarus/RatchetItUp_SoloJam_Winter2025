using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    public TextMeshProUGUI scoreText;

    public bool onExpedition;

    public GameObject scoreKeeper;

    public GameObject gamestopScreen;
    public GameObject gameoverBad;
    public GameObject gameoverGood;
    public GameObject gameoverTrue;

    public GameObject audioManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Turning off end screens
        gamestopScreen.SetActive(false);
        gameoverBad.SetActive(false);
        gameoverGood.SetActive(false);
        gameoverTrue.SetActive(false);

        score = 0;

        onExpedition = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onExpedition = false;
            audioManager.GetComponent<AudioManager>().Play("Ending");
        }

        if (onExpedition == false)
        {
            EndOfGame();
            scoreKeeper.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "W.O.N.D.E.R. " + score.ToString();
    }

    public void EndOfGame()
    {
            gamestopScreen.SetActive(true);

            if (score > 0)
            {
                gameoverBad.SetActive(true);
            }

            else if (score == 0)
            {
                gameoverTrue.SetActive(true);
            }

            else if (score < 0)
            {
                gameoverGood.SetActive(true);
            }

        
    }
}
