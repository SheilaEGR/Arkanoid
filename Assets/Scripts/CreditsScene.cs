
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    private float time = 0;
    
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 5.0f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
