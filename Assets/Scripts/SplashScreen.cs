using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FirstLevelLoad", 2);
    }

    // Update is called once per frame
    void FirstLevelLoad()
    {
        SceneManager.LoadScene(1);
    }
}