using UnityEngine;

public class DetectionTouche : MonoBehaviour
{
    // D�finir la touche que vous voulez d�tecter
    public KeyCode toucheAEcouter = KeyCode.E;

    void Update()
    {
        // V�rifie si la touche sp�cifi�e est enfonc�e
        if (Input.GetKeyDown(toucheAEcouter))
        {
            // V�rifie si le curseur est sur cet objet
            if (IsMouseOverObject())
            {
                // R�agit � l'appui sur la touche E sur cet objet
                Debug.Log("Touche E appuy�e sur l'objet " + gameObject.name);
                // Ajoutez ici les actions que vous souhaitez effectuer lorsque la touche E est enfonc�e sur cet objet
            }
        }
    }

    bool IsMouseOverObject()
    {
        // Lance un rayon depuis la position de la souris dans la sc�ne
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // V�rifie si le rayon frappe cet objet
        if (Physics.Raycast(ray, out hit))
        {
            // V�rifie si l'objet frapp� par le rayon est celui auquel est attach� ce script
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }
}