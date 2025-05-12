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
                break;
            case "Box":
            gameManager.scoreInt++;
            Destroy(other.gameObject);
            gameManager.ballCount--;
            if(gameManager.ballCount == 0 )
            {
                gameManager.Victory();
            }
                break;
        }
    }
    
}
