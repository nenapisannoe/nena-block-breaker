using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] float randomFactor = 0.2f;
    
    [SerializeField ]bool hasStarted = false;
    [SerializeField] AudioClip[] ballSounds;
    Vector2 paddleToballVector;
    private Rigidbody2D myRigidbody2D;
    void Start()
    {
        paddleToballVector = transform.position - paddle1.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();   
        }
        
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToballVector + paddlePos;
    }
    
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2 (velocityX,velocityY);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(hasStarted)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor), Random.Range(0f,randomFactor));
            
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}

