using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;

    private bool _hasPlayer;
    private bool _beingCarried;
    private bool _touched;

    

    [SerializeField] private float pickDistance;

    private static GameObject _carriedObject; // Objet actuellement porté
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        _hasPlayer = dist < pickDistance;

        if (_hasPlayer && Input.GetKeyDown(KeyCode.E) && !_beingCarried && _carriedObject == null) // Vérifier si aucun objet n'est déjà porté
        {
            _rigidbody.isKinematic = true;
            _beingCarried = true;
            _carriedObject = gameObject; // Mettre à jour l'objet actuellement porté
        }

        if (_beingCarried && _carriedObject == gameObject) // Vérifier si l'objet actuellement porté est celui-ci
        {
            if (_touched)
            {
                _rigidbody.isKinematic = false;
                transform.parent = null;
                _beingCarried = false;
                _touched = false;
                _carriedObject = null; // Réinitialiser l'objet actuellement porté
            }

            if (Input.GetMouseButtonDown(0))
            {
                _rigidbody.isKinematic = false;
                _beingCarried = false;
                _carriedObject = null; // Réinitialiser l'objet actuellement porté
                _rigidbody.AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _rigidbody.isKinematic = false;
                _beingCarried = false;
                _carriedObject = null; // Réinitialiser l'objet actuellement porté
            }

            Vector3 objectPos = playerCam.position + playerCam.forward * 3f; // Ajuste la distance entre l'objet et la caméra du joueur
            transform.position = objectPos;
            transform.position += Vector3.up * 1.05f;
            transform.rotation = playerCam.rotation ;
            transform.rotation *= Quaternion.Euler(-15f, 45f, -15f);
            transform.position -= new Vector3(0, 0.5f, 0);





        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_beingCarried)
        {
            _touched = true;
        }
    }

}
