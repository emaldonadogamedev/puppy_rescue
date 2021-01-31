using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static float timeToDeliverDog { get; private set; } = 0f;
    public static float timeRemainingToDeliverDog { get; private set; } = 0f;
    public static bool isDeliveringDog { get; private set; } = false;

    private TimeManager timeManager;

    private static void SetNewDelivery(GameObject currentPerrito, GameObject currentDelivery)
    {
        currentPerritoGrabbed = currentPerrito;
        currentDeliveryPoint = currentDelivery;

        timeToDeliverDog = currentPerritoGrabbed.GetComponent<PerritoBehavior>().timeToDeliver;
        timeRemainingToDeliverDog = timeToDeliverDog;
        isDeliveringDog = true;
    }

    private static void DeliveryDone()
    {
        TimeManager.OnAdjustTime(10f);
        ResetDeliveryData();
    }

    private static void DeliveryMissed()
    {
        ResetDeliveryData();
    }

    private static void ResetDeliveryData()
    {
        isDeliveringDog = false;
        timeRemainingToDeliverDog = 0f;
        currentPerritoGrabbed = null;
        currentDeliveryPoint = null;
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.OnSetTime(5, true, GameMode.TimeLimit);
        timeManager = this.gameObject.GetComponent<TimeManager>();

        perritoKart = GameObject.Find("PerritoKart");
        perritoGrabGO = perritoKart.transform.Find("PerritoGrab").gameObject;

        newDelivery += SetNewDelivery;
        deliveryDone += DeliveryDone;
        deliveryMissed += DeliveryMissed;

        TimeManager.OnRunOutOfTime += GameOver;

        currentPerritoGrabbed = null;
        currentDeliveryPoint = null;
        doneDeliveries = 0;
        missedDeliveries = 0;

        timeToDeliverDog = 0f;
        isDeliveringDog = false;

        timeManager.StartRace();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDeliveringDog)
        {
            timeRemainingToDeliverDog -= Time.deltaTime;

            if(timeRemainingToDeliverDog <= 0f)
            {
                currentPerritoGrabbed.SetActive(false);
                Destroy(currentPerritoGrabbed);

                deliveryMissed?.Invoke();
            }
        }

        // pichea, quiero irme...
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("winScreen");
    }

    private void OnDisable()
    {
        TimeManager.OnRunOutOfTime -= GameOver;

        newDelivery -= SetNewDelivery;
        deliveryDone -= DeliveryDone;
        deliveryMissed -= DeliveryMissed;
        doneDeliveries = 0;
        missedDeliveries = 0;

        timeToDeliverDog = 0f;
        isDeliveringDog = false;
    }
}
