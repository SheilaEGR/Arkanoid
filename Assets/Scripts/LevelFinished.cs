using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinished : MonoBehaviour
{
    private bool countingTime = false;
    private float time=0;

    public void StartTimer()
    {
        time = 0;
        countingTime = true;
    }

    private void Update()
    {
        if (!countingTime) return;

        time += Time.deltaTime;
        if (time >= 2.0f)
            LoadNextScene();

        if (Input.GetKeyDown(KeyCode.Return))
            LoadNextScene();
    }

    private void LoadNextScene()
    {
        countingTime = false;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
