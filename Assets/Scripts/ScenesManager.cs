using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public void ChangementScene(string _nomScene){

        SceneManager.LoadScene(_nomScene);

    }

}

