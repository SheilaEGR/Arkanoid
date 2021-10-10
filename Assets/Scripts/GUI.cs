using UnityEngine;
using UnityEngine.UI;

/**
 * @brief This is the "main" class
 */
public class GUI : MonoBehaviour
{
    public Indicator score;
    public Indicator numBalls;
    public GameOverMenu gameOverMenu;
    public LevelFinished levelFinished;

    private void Start()
    {
        score.SetLabel("SCORE:");
        score.SetValue(Globals.score);

        numBalls.SetLabel("BALLS:");
        numBalls.SetValue(Globals.ballsLeft);

        gameOverMenu.gameObject.SetActive(false);
        levelFinished.gameObject.SetActive(false);

        Globals.numBricks = Globals.bricksByLevel[Globals.level - 1];
        Globals.levelFinished = false;
        Globals.gameOver = false;
    }

    private void Update()
    {
        if(Globals.gameOver)
        {
            gameOverMenu.gameObject.SetActive(true);
        }

        if(Globals.levelFinished)
        {
            levelFinished.gameObject.SetActive(true);
            levelFinished.StartTimer();
        }

        numBalls.SetValue(Globals.ballsLeft);
        score.SetValue(Globals.score);
        
    }
}
