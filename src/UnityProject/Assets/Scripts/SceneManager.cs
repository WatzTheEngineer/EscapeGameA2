using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public string[] tagsToDisable;
    public KeyCode triggerKey; 

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            LoadNewScene(sceneName);
            DisableObjectsWithTags();
           
        }
    }

    void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    
    void DisableObjectsWithTags()
    {
        foreach (string tag in tagsToDisable)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(false); 
            }
        }
    }
}