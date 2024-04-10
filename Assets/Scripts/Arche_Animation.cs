using UnityEngine;

public class Arche_Animation : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player"){
        
            pointage += 1;
            //Debug.Log(pointage);

        }

        else if(other.gameObject.tag == "Arche_Fin" && pointage >= 5){
                
            SceneManager.LoadScene("Fin_Gagnee");

        }

    }

}
