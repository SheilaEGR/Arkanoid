using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 1;

    public int GetPoints()
    {
        return points;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Globals.numBricks--;
        Debug.Log(Globals.numBricks);
        if (Globals.numBricks <= 0)
        {
            Globals.levelFinished = true;
            Globals.level++;
            FindObjectOfType<AudioManager>().Play("LevelComplete");
        }
        Destroy(gameObject);
    }
}
