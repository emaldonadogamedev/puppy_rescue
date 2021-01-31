using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerWidthUpdate : MonoBehaviour
{
    RectTransform rectTransform;

    float initialWidth;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        initialWidth = rectTransform.rect.width;

        PerritoGameManager.deliveryMissed += ResetWidth;
        PerritoGameManager.deliveryDone += ResetWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if(PerritoGameManager.isDeliveringDog)
        {
            var r = rectTransform.rect;
            r.width = initialWidth * (PerritoGameManager.timeRemainingToDeliverDog / PerritoGameManager.timeToDeliverDog);
            rectTransform.sizeDelta = new Vector2(r.width, r.height);
        }
    }

    private void ResetWidth()
    {
        var r = rectTransform.rect;
        r.width = initialWidth;
        rectTransform.sizeDelta = new Vector2(r.width, r.height);
    }

    private void OnDisable()
    {
        PerritoGameManager.deliveryMissed -= ResetWidth;
        PerritoGameManager.deliveryDone -= ResetWidth;
    }
}
