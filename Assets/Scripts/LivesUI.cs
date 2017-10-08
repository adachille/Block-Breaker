using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : GameText {

    Text lives;

	// Use this for initialization
	void Start () {
        lives = GetComponent<Text>();
        setPositionBottom();
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "Lives: " + Paddle.livesLeft.ToString();
	}
}
