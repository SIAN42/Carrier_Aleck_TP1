using UnityEngine;
using UnityEngine.SceneManagement;

public class Pointage : MonoBehaviour
{

    [SerializeField] private float pointage = 0;

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Arche"){
        
            pointage += 1;
            Debug.Log(pointage);

        }

        else if(other.gameObject.tag == "Arche_Fin" && pointage >= 5){
                
            SceneManager.LoadScene("Fin_Gagnee");

        }

    }

}
