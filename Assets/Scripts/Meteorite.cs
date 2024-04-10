using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteorite : MonoBehaviour
{

   private void OnCollisionEnter(Collision other) {
      
      if(other.gameObject.name == "Voiture"){

         SceneManager.LoadScene("Fin_Perdu");         

      }

   }

}
