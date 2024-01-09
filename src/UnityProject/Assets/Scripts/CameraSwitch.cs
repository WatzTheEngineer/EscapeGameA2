using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras; // Tableau des caméras à changer
    private int currentCameraIndex; // Index de la caméra actuelle
    private bool isRunning = true;
    public string[] tagsToEnableDisable;

    void Start()
    {
        currentCameraIndex = 0; // Commence avec la première caméra
        UpdateCameraVisibility();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            SwitchCamera();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        currentCameraIndex++; // Incrémente l'index de la caméra actuelle
        if (currentCameraIndex >= cameras.Length) // Si on atteint la fin du tableau
        {
            currentCameraIndex = 0; // Reviens à la première caméra
        }
        UpdateCameraVisibility();
    }

    void UpdateCameraVisibility()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCameraIndex)
            {
                cameras[i].enabled = true; // Active la caméra actuelle
            }
            else
            {
                cameras[i].enabled = false; // Désactive les autres caméras
            }
        }
    }

    void SetActiveObjectsWithTags()
    {
        foreach (string tag in tagsToEnableDisable)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(true);
            }
        }
    }

    void SetInactiveObjectsWithTags()
    {
        foreach (string tag in tagsToEnableDisable)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(false);
            }
        }
    }
}