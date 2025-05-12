using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public bool canMove;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        Controller();
    }

    void Controller()
    {
        if(Input.GetKey(KeyCode.D) && canMove)
        {
            transform.position += new Vector3(0.7f,0,0) * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A) && canMove)
        {
            transform.position -= new Vector3(0.7f,0,0) * moveSpeed * Time.deltaTime;
        }
    }
}
