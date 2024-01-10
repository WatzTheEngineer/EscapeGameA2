using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public string objectName = "ObjectToInteract"; // Remplacez "ObjectToInteract" par le nom de votre objet

    void Update()
    {
        // V�rifie si la touche "E" est enfonc�e
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Rayon depuis le centre de l'�cran
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            RaycastHit hit;
            // V�rifie si le rayon touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // V�rifie si l'objet touch� a le m�me nom que celui sp�cifi� dans objectName
                if (hit.collider.gameObject.name == objectName)
                {
                    // Si c'est l'objet sp�cifique, envoie un message dans la console
                    Debug.Log("Touche 'E' press�e sur : " + objectName);
                }
            }
        }
    }
}
