using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyonLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
