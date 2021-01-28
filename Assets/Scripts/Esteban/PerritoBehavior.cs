using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerritoBehavior : MonoBehaviour
{
    public GameObject destinationOwner;
    public GameObject kartGameObject;

    private bool isGrabbedFromStreet = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbedFromStreet)
        {
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == kartGameObject)
        {
            isGrabbedFromStreet = true;

            this.transform.SetParent(kartGameObject.transform);
        }

        if(other.gameObject == destinationOwner && isGrabbedFromStreet)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    public float DestinationFromOwner()
    {
        if (destinationOwner == null)
        {
            return -1f;
        }

        return (destinationOwner.transform.position - transform.position).magnitude;
    }

}
