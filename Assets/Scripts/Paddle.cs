using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    
    public static int livesLeft;
    public bool autoPlay;

    private float autoPlayOffsetX;

    const int BLOCKS_IN_SCREEN = 16;
    private float mousePosXInBlocks;
    private Vector3 paddlePos;

    private Ball ball;

    // Use this for initialization
    void Start () {

        // This means the user has 5 total lives
        if (livesLeft <= 0)
        {
            livesLeft = 4;
        }

        mousePosXInBlocks = 0.0f;
        paddlePos = this.transform.position;

        ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (autoPlay) { AutoPlay(); }
        else { MoveWithMouse(); }
        
	}

    // Moves paddle with ball
    void AutoPlay()
    {
        paddlePos.x = Mathf.Clamp(ball.transform.position.x + autoPlayOffsetX, 0.75f, 15.25f);
        this.transform.position = paddlePos;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        autoPlayOffsetX = Random.Range(-0.5f, 0.5f);
    }

    void MoveWithMouse()
    {
        mousePosXInBlocks = (Input.mousePosition.x / Screen.width * BLOCKS_IN_SCREEN) - 0.5f;
        paddlePos.x = Mathf.Clamp(mousePosXInBlocks, 0.75f, 15.25f);

        this.transform.position = paddlePos;
    }
}
