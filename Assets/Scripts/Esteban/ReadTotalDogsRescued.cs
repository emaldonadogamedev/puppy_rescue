﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadTotalDogsRescued : MonoBehaviour
{
    Text uiText;
    public bool updateTheText = false;

    // Start is called before the first frame update
    void Start()
    {
        uiText = gameObject.GetComponent<Text>();
        uiText.text = $"{PerritoGameManager.totalRescuedDogs}";
    }

    // Update is called once per frame
    void Update()
    {
        if(updateTheText)
        {
            uiText.text = $"{PerritoGameManager.totalRescuedDogs}";
        }
    }
}
