using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class LogicHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public AudioSource gameOverSound;
    public AudioSource click;
    public int playerScore = 0;


    [ContextMenu("increase score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void onClickButton()
    {
        click.Play();
        Invoke("Restart", 0.1f);
    }
    
    public void Restart()
    {
        playerScore = 0;
        scoreText.text = "Score: " + playerScore.ToString();
        gameOverScreen.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    private void playGameOverSound()
    {
        gameOverSound.Play();
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Invoke("playGameOverSound", 1.5f);
    }
}

