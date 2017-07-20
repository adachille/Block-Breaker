using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (Paddle.livesLeft <= 0)
        {
            // Resets the breakable count so that it doesn't carry over games
            Brick.breakableCount = 0;
            LevelManager lm = FindObjectOfType<LevelManager>();
            lm.LoadLevel("Lose");
        } else
        {
            // Decrement lives left, create a new ball and destroy the old ball
            Paddle.livesLeft--;

            Ball ball = new Ball();
            Ball.Instantiate(ball);

            DestroyObject(FindObjectOfType<Ball>());
        }
    }
}
