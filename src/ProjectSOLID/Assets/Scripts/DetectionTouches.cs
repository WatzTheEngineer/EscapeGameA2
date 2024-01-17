using UnityEngine;

public class DetectionTouche : MonoBehaviour
{
    // Définir la touche que vous voulez détecter
    public KeyCode toucheAEcouter = KeyCode.E;

    void Update()
    {
        // Vérifie si la touche spécifiée est enfoncée
        if (Input.GetKeyDown(toucheAEcouter))
        {
            // Vérifie si le curseur est sur cet objet
            if (IsMouseOverObject())
            {
                // Réagit à l'appui sur la touche E sur cet objet
                Debug.Log("Touche E appuyée sur l'objet " + gameObject.name);
                // Ajoutez ici les actions que vous souhaitez effectuer lorsque la touche E est enfoncée sur cet objet
            }
        }
    }

    bool IsMouseOverObject()
    {
        // Lance un rayon depuis la position de la souris dans la scène
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Vérifie si le rayon frappe cet objet
        if (Physics.Raycast(ray, out hit))
        {
            // Vérifie si l'objet frappé par le rayon est celui auquel est attaché ce script
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }
}