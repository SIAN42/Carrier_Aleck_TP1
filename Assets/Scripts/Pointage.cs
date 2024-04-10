using UnityEngine;
using UnityEngine.SceneManagement;

public class Pointage : MonoBehaviour
{

    [SerializeField] private float pointage = 0;

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Arche"){
        
            pointage += 1;

        }

        else if(other.gameObject.tag == "Arche_Fin"){
        
            if(pointage >= 6){
                
                SceneManager.LoadScene("Fin_Gagnee");
                
            }

        }

    }

}
