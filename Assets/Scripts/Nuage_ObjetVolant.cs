using UnityEngine;

public class Nuage_ObjetVolant : MonoBehaviour
{

    [SerializeField] private float _vitesse = 2f;

    //[SerializeField] private string _direction = "forward";

    
    void Update(){
        
        transform.Translate(Vector3.forward * _vitesse * Time.deltaTime);

    }
}
