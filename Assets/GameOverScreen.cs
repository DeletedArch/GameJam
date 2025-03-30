using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{   public Text pointsText;
    public void SetUp(ref int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Coins";
        score = 0;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu 1");
    }
    
}
