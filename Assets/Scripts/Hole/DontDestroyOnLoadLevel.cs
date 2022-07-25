using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadLevel : MonoBehaviour
{
    public static DontDestroyOnLoadLevel load { get; private set; }

    public Fox fox;

    public int healthPoints;

    //public static Fox fox = new Fox();   //
    private void Awake()
    {
        healthPoints = fox.Health;
        if (load == null)
        {
            load = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(load != this)
        {
            Destroy(gameObject);
        }
        
        //healthPoints = fox.Health;
    }

}
