using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static bool resetGame        = false;
    public static bool gameOver         = false;
    public static bool levelFinished    = true;

    public static int score     = 0;
    public static int ballsLeft = 3;
    public static int numBricks = 50;
    public static int level     = 1;

    public static int[] bricksByLevel = new int[] { 50, 72 };
}
