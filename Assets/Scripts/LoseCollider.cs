using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (Paddle.livesLeft <= 1)
        {
            // Resets the breakable count so that it doesn't carry over games
            LevelManager lm = FindObjectOfType<LevelManager>();
            Brick.breakableCount = 0;
            lm.LoadLevel("Lose");
        } else
        {
            // Decrement lives left, reset ball
            Paddle.livesLeft--;

            FindObjectOfType<Ball>().ResetBall();
        }
    }
}
