using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public static int breakableCount = 0;
    public Sprite[] hitSprites;

    private bool isBreakable;
    private LevelManager manager;
    private int timesHit;


	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) { breakableCount++; }

        timesHit = 0;
        manager = FindObjectOfType<LevelManager>();
    }
	
    // Detroys block if hitsLeft is 0, or decrements its color
    void OnCollisionExit2D(Collision2D collision)
    {
        if (isBreakable) { HandleHits(); }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        // Destroys brick if necessary
        if (timesHit >= maxHits) {
            breakableCount--;
            Destroy(gameObject);
        }

        // Changes sprite for brick if necessary
        LoadSprites();

        // Check to see if level needs to be changed
        manager.BrickDestroyed();
    }

    void LoadSprites()
    {

        int spriteIndex = timesHit - 1;

        if (spriteIndex < hitSprites.Length && hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        
    }
}
