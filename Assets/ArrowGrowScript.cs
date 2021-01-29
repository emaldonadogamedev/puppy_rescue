using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGrowScript : MonoBehaviour
{
    public float intensity = 1.0f;
    public float lowerScaleVal = .5f;
    public float higherScaleVal = 1.3f;

    private Vector3 scale = new Vector3(1,1,1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float v = Mathf.Abs(Mathf.Sin(Time.time * intensity));
        float v = Mathf.Lerp(lowerScaleVal, higherScaleVal, Mathf.Abs(Mathf.Sin(Time.time * intensity)));

        scale.Set(v, v, v);
        this.transform.localScale = scale;
    }
}
