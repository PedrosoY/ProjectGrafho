using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public InGame game;
    public Text txtPoints;

    // Update is called once per frame
    void Update()
    {
        txtPoints.text = "SCORE: " + game.points.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        Enemy.ResetSpeed();
    }
}
