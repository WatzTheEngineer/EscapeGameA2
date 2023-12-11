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

        private Vector3 objectPos;
        private float distance;

        // Start is called before the first frame update
        void Start()
        {
            objectPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            float dist = Vector3.Distance(gameObject.transform.position, player.position);

            if (dist < 3f)
            {
                hasPlayer = true;
            }
            else
            {
                hasPlayer = false;
            }

            if (hasPlayer && Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<Rigidbody>().isKinematic = true;
                distance = Vector3.Distance(gameObject.transform.position, player.position);
                beingCarried = true;
            }

            if (beingCarried)
            {
                if (touched)
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    beingCarried = false;
                    touched = false;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    beingCarried = false;
                    GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    beingCarried = false;
                }

                // Update the position of the object relative to the player camera
                objectPos = playerCam.position + playerCam.forward * distance;
                transform.position = objectPos;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (beingCarried)
            {
                touched = true;
            }
        }
    }
