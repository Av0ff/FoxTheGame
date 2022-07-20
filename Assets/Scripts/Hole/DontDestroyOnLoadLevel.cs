using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadLevel : MonoBehaviour
{
    public static DontDestroyOnLoadLevel load { get; private set; }

    public int healthPoints { get; set; }

    //public Fox fox;
    private void Awake()
    {
        if (load != null)
        {
            Destroy(gameObject);
            return;
        }
        load = this;
        DontDestroyOnLoad(gameObject);

        //healthPoints = fox.Health;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }    
}
