using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        switch (currentScene)
        {
            case 0:
                SceneManager.LoadScene(1);
                break;
            case 1:
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
    }

    public void RestartLevel()
    {
        var fox = GameObject.FindObjectOfType<Fox>();
        fox.Health = 10;
        DontDestroyOnLoadLevel.Load.Food = 0;
        SceneManager.LoadScene(0);
    }
}
