using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;

    [SerializeField] public float pickDistance;

    public bool isPlayerNear;
    public bool isBeingCarried;
    private bool isTouched;

    public static GameObject carriedObject;
    private Rigidbody rigidbody;

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckPlayerProximity();

        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !isBeingCarried && carriedObject == null)
        {
            PickObject();
        }

        if (isBeingCarried && carriedObject == gameObject)
        {
            HandleCarriedObject();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isBeingCarried)
        {
            isTouched = true;
        }
    }

    public void CheckPlayerProximity()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        isPlayerNear = distanceToPlayer < pickDistance;
    }

    public void PickObject()
    {
        rigidbody.isKinematic = true;
        isBeingCarried = true;
        carriedObject = gameObject;
    }

    private void HandleCarriedObject()
    {
        if (isTouched)
        {
            ReleaseObject();
        }

        if (Input.GetMouseButtonDown(0))
        {
            ThrowObject();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ReleaseObject();
        }

        UpdateObjectPosition();
    }

    private void ReleaseObject()
    {
        rigidbody.isKinematic = false;
        transform.parent = null;
        isBeingCarried = false;
        isTouched = false;
        carriedObject = null;
    }

    private void ThrowObject()
    {
        rigidbody.isKinematic = false;
        isBeingCarried = false;
        carriedObject = null;
        rigidbody.AddForce(playerCam.forward * throwForce);
    }

    private void UpdateObjectPosition()
    {
        Vector3 objectPos = playerCam.position + playerCam.forward * 3f;
        transform.position = objectPos;
        transform.position += Vector3.up * 1.05f;
        transform.rotation = playerCam.rotation;
        transform.rotation *= Quaternion.Euler(-15f, 45f, -15f);
        transform.position -= new Vector3(0, 0.5f, 0);
    }
}
