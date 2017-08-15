using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private float timeTillGame;

    private bool onTransitionScreen;

	// Use this for initialization
	void Start () {
        onTransitionScreen = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (onTransitionScreen)
        {
            timeTillGame -= Time.deltaTime;
            if (timeTillGame <= 0)
            {
                onTransitionScreen = false;
                gameObject.transform.position = new Vector3(8, 6, -10);
            }
        }
	}
}
