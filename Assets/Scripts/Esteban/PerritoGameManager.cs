using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerritoGameManager : MonoBehaviour
{
    public static Action<GameObject, GameObject> newDelivery;
    public static Action deliveryDone;
    public static Action deliveryMissed;

    public static GameObject currentPerritoGrabbed { get; private set; }
    public static GameObject currentDeliveryPoint { get; private set; }
    public static GameObject perritoGrabberItem => perritoGrabGO;

    public static int doneDeliveries { get; private set; }
    public static int missedDeliveries { get; private set; }

    public static int totalDeliveries => doneDeliveries + missedDeliveries;

    static private GameObject perritoKart;
    static private GameObject perritoGrabGO;

    private static void SetNewDelivery(GameObject currentPerrito, GameObject currentDelivery)
    {
        currentPerritoGrabbed = currentPerrito;
        currentDeliveryPoint = currentDelivery;
    }

    private static void DeliveryDone()
    {
        ResetDeliveryData();
    }

    private static void DeliveryMissed()
    {
        ResetDeliveryData();
    }

    private static void ResetDeliveryData()
    {
        SetNewDelivery(null, null);
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.OnSetTime(60, true, GameMode.TimeLimit);

        perritoKart = GameObject.Find("PerritoKart");
        perritoGrabGO = perritoKart.transform.Find("PerritoGrab").gameObject;

        newDelivery += SetNewDelivery;
        deliveryDone += DeliveryDone;
        deliveryMissed += DeliveryMissed;

        currentPerritoGrabbed = null;
        currentDeliveryPoint = null;
        doneDeliveries = 0;
        missedDeliveries = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        newDelivery -= SetNewDelivery;
        deliveryDone -= DeliveryDone;
        deliveryMissed -= DeliveryMissed;
        doneDeliveries = 0;
        missedDeliveries = 0;
    }
}
