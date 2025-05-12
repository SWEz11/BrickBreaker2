using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [SerializeField] GameObject gameOverText;
    public GameObject ball;
    [SerializeField] PaddleController paddleController;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text dropText;
    public int dropInt;
    public int scoreInt;
    public int highScoreInt;
    [SerializeField] AudioSource gameOverSoundEffect;

    void Start()
    {
        Load();
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
        Save();
        
    }

    //PlayAgain
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void UpdateUI()
    {
        scoreText.text = "Score " + scoreInt.ToString();
        dropText.text = "Drop: " + dropInt.ToString();
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
