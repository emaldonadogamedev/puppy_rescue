using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PerritoGameManager : MonoBehaviour
{
    private static GameObject currentPerritoGrabbed;
    private static GameObject currentDeliveryPoint;

    private static UnityEvent deliveryDone;
    private static UnityEvent deliveryMissed;

    private GameObject perritoKart;

    public static void SetNewDelivery(GameObject currentPerrito, GameObject currentDelivery)
    {
        currentPerritoGrabbed = currentPerrito;
        currentDeliveryPoint = currentDelivery;
    }

    public static void DeliveryDone()
    {
        deliveryDone.Invoke();
        ResetDeliveryData();
    }

    public static void DeliveryMissed()
    {
        deliveryMissed.Invoke();
        ResetDeliveryData();
    }

    private static void ResetDeliveryData()
    {
        SetNewDelivery(null, null);
    }

    // Start is called before the first frame update
    void Start()
    {
        perritoKart = GameObject.Find("PerritoKart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        deliveryDone.RemoveAllListeners();
        deliveryMissed.RemoveAllListeners();
    }
}
