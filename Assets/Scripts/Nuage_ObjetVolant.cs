using UnityEngine;

public class Nuage_ObjetVolant : MonoBehaviour
{

    [SerializeField] private float vitesse = 1;

    //[SerializeField] private string _direction = "foward";

    [SerializeField] private float repeatTime = 0.5f;

    
    void Update()
    {
        
        transform.Translate(Vector3.foward * vitesse * Time.deltaTime)

    }
}
