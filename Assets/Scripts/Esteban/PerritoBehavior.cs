using UnityEngine;

[ExecuteInEditMode]
public class PerritoBehavior : MonoBehaviour
{
    public enum DOG_TYPE
    {
        FAR,
        NORMAL,
        CLOSE,
    }

    public GameObject destinationOwner;

    public float timeToDeliver = 9f;
    public DOG_TYPE dogType = DOG_TYPE.CLOSE;
    private bool isGrabbedFromStreet = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == PerritoGameManager.perritoGrabberItem)
        {
            isGrabbedFromStreet = true;          
            transform.SetParent(PerritoGameManager.perritoGrabberItem.transform);
        }

        // dog delivered
        if(other.gameObject == destinationOwner && isGrabbedFromStreet)
        {
            isGrabbedFromStreet = false;

            this.gameObject.SetActive(false);
            Destroy(this.gameObject);

            destinationOwner.SetActive(false);

            PerritoGameManager.deliveryDone.Invoke();
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
