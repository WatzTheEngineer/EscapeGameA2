using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras; // Tableau des cam�ras � changer
    private int currentCameraIndex; // Index de la cam�ra actuelle
    //private bool isRunning = true;
    public string[] tagsToEnableDisable;

    void Start()
    {
        currentCameraIndex = 0; // Commence avec la premi�re cam�ra
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
        currentCameraIndex++; // Incr�mente l'index de la cam�ra actuelle
        if (currentCameraIndex >= cameras.Length) // Si on atteint la fin du tableau
        {
            currentCameraIndex = 0; // Reviens � la premi�re cam�ra
        }
        UpdateCameraVisibility();
    }

    void UpdateCameraVisibility()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCameraIndex)
            {
                cameras[i].enabled = true; // Active la cam�ra actuelle
            }
            else
            {
                cameras[i].enabled = false; // D�sactive les autres cam�ras
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