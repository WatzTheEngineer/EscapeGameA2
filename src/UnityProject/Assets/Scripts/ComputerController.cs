using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public string objectName = "ObjectToInteract"; // Remplacez "ObjectToInteract" par le nom de votre objet

    void Update()
    {
        // Vérifie si la touche "E" est enfoncée
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Rayon depuis le centre de l'écran
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;
            // Vérifie si le rayon touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifie si l'objet touché a le même nom que celui spécifié dans objectName
                if (hit.collider.gameObject.name == objectName)
                {
                    // Si c'est l'objet spécifique, envoie un message dans la console
                    Debug.Log("Touche 'E' pressée sur : " + objectName);
                }
            }
        }
    }
}
