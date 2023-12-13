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

    private static GameObject carriedObject = null; // Objet actuellement porté

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

        if (hasPlayer && Input.GetKeyDown(KeyCode.E) && !beingCarried && carriedObject == null) // Vérifier si aucun objet n'est déjà porté
        {
            GetComponent<Rigidbody>().isKinematic = true;
            beingCarried = true;
            carriedObject = gameObject; // Mettre à jour l'objet actuellement porté
        }

        if (beingCarried && carriedObject == gameObject) // Vérifier si l'objet actuellement porté est celui-ci
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce * -50);
                Debug.Log(playerCam.forward * throwForce);
                carriedObject = null; // Réinitialiser l'objet actuellement porté
            }

            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                beingCarried = false;
                carriedObject = null; // Réinitialiser l'objet actuellement porté
                GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                beingCarried = false;
                carriedObject = null; // Réinitialiser l'objet actuellement porté
            }

            Vector3 objectPos = playerCam.position + playerCam.forward * 3f; // Ajuste la distance entre l'objet et la caméra du joueur
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
