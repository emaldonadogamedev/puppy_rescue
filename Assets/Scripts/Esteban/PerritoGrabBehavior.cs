using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerritoGrabBehavior : MonoBehaviour
{
    public GameObject arrowMarker;

    private PerritoBehavior currentPerritoBehavior = null;

    private GameObject destinationForPerrito = null;

    // Start is called before the first frame update
    void Start()
    {
        PerritoGameManager.deliveryMissed += TurnOffArrow;
        PerritoGameManager.deliveryDone += TurnOffArrow;
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

    private void TurnOffArrow()
    {
        this.arrowMarker.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        currentPerritoBehavior = other.gameObject.GetComponent<PerritoBehavior>();
        if (currentPerritoBehavior != null)
        {
            destinationForPerrito = currentPerritoBehavior.destinationOwner;
            arrowMarker.SetActive(true);

            PerritoGameManager.newDelivery.Invoke(currentPerritoBehavior.gameObject, destinationForPerrito);
        }
    }

    private void OnDisable()
    {
        PerritoGameManager.deliveryMissed -= TurnOffArrow;
        PerritoGameManager.deliveryDone -= TurnOffArrow;
    }
}
