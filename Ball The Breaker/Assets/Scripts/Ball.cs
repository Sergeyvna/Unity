using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public Paddle paddle1;
    public float xPush = 2f;
    public float yPush = 15f;

    private Vector2 paddleToBallVector;
    private bool hasStarted = false;
    private AudioSource playMyAudio;
    private Rigidbody2D ballRigidbody2D;

    // Start is called before the first frame update
    private void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        playMyAudio = GetComponent<AudioSource>();
        ballRigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {

        if(!hasStarted)
        {
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
    }



    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2 (0, yPush); 
            hasStarted = true;
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            playMyAudio.Play();
            ballRigidbody2D.AddForce(new Vector2(xPush,yPush));
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "LooseCollider")
        {
            FindObjectOfType<GameSession>().DecreaseLives();
            hasStarted = false;
        }
    }

    public void ResetBall()
    {
        hasStarted = false;
    }
}
