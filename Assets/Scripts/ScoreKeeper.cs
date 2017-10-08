using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {
    private static int score;

    public static int GetScore() { return score; }
    public static void Score() { score += 10; }
    public static void ResetScore() { score = 0; }
}
