using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private string tag;
    [SerializeField] PaddleController paddleController;
    [SerializeField] GameManager gameManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        tag = other.gameObject.tag;

        switch(tag)
        {
            case "Ground":
            gameManager.dropInt++;
            if(gameManager.dropInt >= 3)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.ball.transform.position = new Vector3(0,0,0);
            }
                break;
            case "Box":
            gameManager.scoreInt++;
            gameManager.UpdateUI();
            other.gameObject.SetActive(false);
                break;
        }
    }
    
}
