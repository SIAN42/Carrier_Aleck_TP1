using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteorite : MonoBehaviour
{

    

    seriali




    void Start()
    {
        
    }
    


    [SerializeField] private Animator myDoor;

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")){

            SceneManager.LoadScene(_nomScene);
            myDoor.SetBool("IsOpen", false);
            

        }

    }

    private void OnTriggerExit(Collider other) {
    
        if (other.CompareTag("Player")){

            myDoor.SetBool("IsOpen", false);

        }

    }

}
