using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    public static int score = 0 ;
    // Start is called before the first frame update
    
    public GameObject GameOverPanel;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString() + " Coins";
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        //Time.timeScale = 0;
    }
    public void RestartGame()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void AddCoin()
    {
        score +=1;
        scoreText.text = score.ToString() + " Coins";
    }

}
