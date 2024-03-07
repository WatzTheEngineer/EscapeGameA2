using UnityEngine;

public class doorController : MonoBehaviour
{
    public float vitesseDescendre = 0.01f; 

    void Update()
    {
        
        float deplacementY = vitesseDescendre * Time.deltaTime;

        
        transform.Translate(Vector3.down * deplacementY);
    }
}
