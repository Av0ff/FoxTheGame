using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHome : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void GoRaid()
    {
        SceneManager.LoadScene(1);
    }
}
