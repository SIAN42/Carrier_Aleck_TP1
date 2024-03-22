using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void DébutJeu(string _nomScene){

        SceneManager.LoadScene(_nomScene);

    }

}
