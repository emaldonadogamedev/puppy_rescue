﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    
    public void mainTestCollectPuppyMenu()
    {
        SceneManager.LoadScene("TestCollectPuppy");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void restart()
    {
        SceneManager.LoadScene("TestCollectPuppy");
    }


    public void credits()
    {
        SceneManager.LoadScene("credits");
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}