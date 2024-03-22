using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void ChangementScene(string _nomScene){

        SceneManager.LoadScene(_nomScene);

    }

}
