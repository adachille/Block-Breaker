using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : GameText {

    Text score;

	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        setPositionBottom();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + ScoreKeeper.GetScore().ToString();
	}
}
