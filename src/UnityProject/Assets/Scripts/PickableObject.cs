using UnityEngine;
using Utils;

public class PickableObject : MonoBehaviour, IRaycastable
{
    public static GameObject CarriedObject;
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;

    [SerializeField] public float pickDistance;

    public bool isPlayerNear;
    public bool isBeingCarried;
    private bool _isTouched;
    private Rigidbody _rigidbody;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (isBeingCarried && CarriedObject == gameObject) HandleCarriedObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBeingCarried) _isTouched = true;
    }

    public void OnRaycastDo()
    {
        if (!isBeingCarried && CarriedObject == null) PickObject();
    }

    public void PickObject()
    {
        _rigidbody.isKinematic = true;
        isBeingCarried = true;
        CarriedObject = gameObject;
    }

    private void HandleCarriedObject()
    {
        if (_isTouched) ReleaseObject();

        if (Input.GetMouseButtonDown(0))
            ThrowObject();
        else if (Input.GetMouseButtonDown(1)) ReleaseObject();

        UpdateObjectPosition();
    }

    private void ReleaseObject()
    {
        _rigidbody.isKinematic = false;
        transform.parent = null;
        isBeingCarried = false;
        _isTouched = false;
        CarriedObject = null;
    }

    private void ThrowObject()
    {
        _rigidbody.isKinematic = false;
        isBeingCarried = false;
        CarriedObject = null;
        _rigidbody.AddForce(playerCam.forward * throwForce);
    }

    private void UpdateObjectPosition()
    {
        var objectPos = playerCam.position + playerCam.forward * 3f;
        transform.position = objectPos;
        transform.position += Vector3.up * 1.30f;
        transform.rotation = playerCam.rotation;
        transform.rotation *= Quaternion.Euler(-15f, 45f, -15f);
        transform.position -= new Vector3(0, 0.5f, 0);
    }
}