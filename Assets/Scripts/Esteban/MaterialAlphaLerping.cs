using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAlphaLerping : MonoBehaviour
{
    public float intensity = 1.0f;
    public float lowerScaleVal = .2f;
    public float higherScaleVal = 1f;

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(meshRenderer != null)
        {
            float v = Mathf.Lerp(lowerScaleVal, higherScaleVal, Mathf.Abs(Mathf.Sin(Time.time * intensity)));

            var c = meshRenderer.material.color;
            c.a = v;
            meshRenderer.material.color = c;
        }
    }
}
