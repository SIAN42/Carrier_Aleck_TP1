using UnityEngine;

public class Nuage_ObjetVolant : MonoBehaviour
{

    [SerializeField] private float _vitesse = 1f;

    [SerializeField] private float _direction = 1f;

    [SerializeField] private float repeatTime = 0.5f;

    
    void Update()
    {
        
        transform.Translate(Vector3._direction * _vitesse * Time.deltaTime)

    }
}
