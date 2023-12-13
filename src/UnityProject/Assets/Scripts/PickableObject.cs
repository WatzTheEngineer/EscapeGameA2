using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;

    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    private static GameObject carriedObject = null; // Objet actuellement port�

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist < 2f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && Input.GetKeyDown(KeyCode.E) && !beingCarried && carriedObject == null) // V�rifier si aucun objet n'est d�j� port�
        {
            GetComponent<Rigidbody>().isKinematic = true;
            beingCarried = true;
            carriedObject = gameObject; // Mettre � jour l'objet actuellement port�
        }

        if (beingCarried && carriedObject == gameObject) // V�rifier si l'objet actuellement port� est celui-ci
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce * -50);
                Debug.Log(playerCam.forward * throwForce);
                carriedObject = null; // R�initialiser l'objet actuellement port�
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                beingCarried = false;
                carriedObject = null; // R�initialiser l'objet actuellement port�
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                beingCarried = false;
                carriedObject = null; // R�initialiser l'objet actuellement port�
            }

            Vector3 objectPos = playerCam.position + playerCam.forward * 3f; // Ajuste la distance entre l'objet et la cam�ra du joueur
            transform.position = objectPos;
        }
    }

    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
