﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerritoGrabBehavior : MonoBehaviour
{
    public GameObject arrowMarker;
    private Vector2 arrowMarkerXZpos;

    private PerritoBehavior currentPerritoBehavior = null;

    private GameObject destinationForPerrito = null;
    private Vector2 destinationForPerritoXZpos;

    private 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(arrowMarker.activeSelf)
        {
            arrowMarker.transform.LookAt(destinationForPerrito.transform.position, Vector3.up);

            var rot = arrowMarker.transform.rotation.eulerAngles;
            rot.x = rot.z = 0;

            arrowMarker.transform.rotation = Quaternion.Euler(rot);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        currentPerritoBehavior = other.gameObject.GetComponent<PerritoBehavior>();
        if (currentPerritoBehavior != null)
        {
            destinationForPerrito = currentPerritoBehavior.destinationOwner;
            destinationForPerritoXZpos = new Vector2(destinationForPerrito.transform.position.x, destinationForPerrito.transform.position.z);
            arrowMarker.SetActive(true);
        }
    }
}
