using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject victoryText;
    public GameObject ball;
    [SerializeField] PaddleController paddleController;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text dropText;
    public int dropInt;
    public int scoreInt;
    public int highScoreInt;
    public int ballCount;
    [SerializeField] AudioSource gameOverSoundEffect;
    [SerializeField] AudioSource victorySoundEffect;

    void Start()
    {
        ballCount = 5;
        Load();
        print(highScoreInt);
    }
    void Update()
    {
        UpdateUI();
    }

    //GameOver
    public void GameOver()
    {
        gameOverText.SetActive(true);
        gameOverSoundEffect.Play();
        ball.SetActive(false);
        ball.transform.position = new Vector3(0,0,0);
        paddleController.canMove = false;

        //Check for HighScore
        if(scoreInt > highScoreInt)
        {
            highScoreInt = scoreInt;
        }
        highScoreText.text = "High Score: " + highScoreInt.ToString();
        Save();
    }

    public void Victory()
    {
        victoryText.SetActive(true);
        gameOverSoundEffect.Play();
        ball.SetActive(false);
        ball.transform.position = new Vector3(0,0,0);
        paddleController.canMove = false;
        //Check for HighScore
        if(scoreInt > highScoreInt)
        {
           highScoreInt = scoreInt;
        }
        Save();
    }

    //PlayAgain
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + scoreInt.ToString();
        dropText.text = "Drop Left: " + dropInt.ToString();
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("HighScore", highScoreInt);
    }

    void Load()
    {
        highScoreInt = PlayerPrefs.GetInt("HighScore");
    }
}
