using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector2 ballVelocity;

    private bool hasStarted = false;
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rb;
    private AudioSource bounceAudio;

    // Use this for initialization
    void Start () {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        bounceAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            // Lock ball relative to paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for mouse to start game or auto start it
            if (Input.GetMouseButtonDown(0) || paddle.autoPlay)
            {
                print("Mouse clicked, launch ball");
                rb.velocity = ballVelocity;
                hasStarted = true;
            } 
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            bounceAudio.Play();

            // Tweak makes it so that the new x component of the velocity is partly determined
            // by where it collided with the paddle.
            float newX;
            if (collision.gameObject.tag == "Paddle")
            {
                newX = (this.transform.position.x - paddle.transform.position.x) * 12;
            } else
            {
                newX = rb.velocity.x + Random.Range(0.0f, 1.0f);
            }

            float newY = rb.velocity.y + Random.Range(0.0f, 1.0f);


            // Maintains -8 <= x.velocity <= 8    and    -8 <= y.velocity <= 10
            if (newX > 6) { newX = 6; }
            if (newY > 8) { newY = 8; }
            if (newX < -6) { newX = -6; }
            if (newY < -6) { newY = -6; }

            // Maintains the balls speed 
            rb.velocity = new Vector2(newX, newY);
            if (rb.velocity.magnitude < 6)
            {
                rb.velocity += rb.velocity.normalized * 2.0f;
            }
        }
    }
    
    // Returns the ball to the paddle after a life is lost
    public void ResetBall()
    {
        hasStarted = false;
    }
}
