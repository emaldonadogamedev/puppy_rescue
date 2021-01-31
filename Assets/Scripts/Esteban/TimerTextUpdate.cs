using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTextUpdate : MonoBehaviour
{
    Text uiText;
    TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        uiText = gameObject.GetComponent<Text>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = $"{Mathf.RoundToInt(timeManager.TimeRemaining)}";
    }
}
