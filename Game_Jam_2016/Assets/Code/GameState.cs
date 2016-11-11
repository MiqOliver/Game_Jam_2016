using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public float addSpeed;
    public float maxSpeed;
    public float speed;

    public GUIText scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        if (speed < maxSpeed)
        {
            speed += addSpeed * Time.deltaTime;
        }
        else if(speed > maxSpeed)
            speed = maxSpeed;

        Restart();
    }

    public void Restart()
    {
        //Restarting Scene
        if (GameObject.FindWithTag("Player") == null)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
    public void RestartButton()
    {

        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
    }
    public void Quit()
    {
        Application.Quit();
    }

    void UpdateScore()
    {
        scoreText.text = "" + score;
    }
}
