using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Color colorSelected;
    public Color colorUnselected;

    private Text tryAgain;
    private Text exitGame;
    private bool tryAgainSelected = true;
    private AudioManager audioManager;

    private void Awake()
    {
        tryAgain = transform.Find("TryAgain").GetComponent<Text>();
        tryAgain.color = colorSelected;

        exitGame = transform.Find("ExitGame").GetComponent<Text>();
        exitGame.color = colorUnselected;

        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        {
            tryAgainSelected = !tryAgainSelected;
            UpdateColor();
            audioManager.Play("CollectItem");
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            audioManager.Play("CollectItem");
            ReloadScene();
        }
    }


    private void UpdateColor()
    {
        if (tryAgainSelected)
        {
            tryAgain.color = colorSelected;
            exitGame.color = colorUnselected;
        }
        else
        {
            tryAgain.color = colorUnselected;
            exitGame.color = colorSelected;
        }
    }

    private void ReloadScene()
    {
        if (tryAgainSelected)
        {
            gameObject.SetActive(false);
            Globals.gameOver = false;
            Globals.resetGame = false;
            Globals.ballsLeft = 3;
            Globals.score = 0;

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
