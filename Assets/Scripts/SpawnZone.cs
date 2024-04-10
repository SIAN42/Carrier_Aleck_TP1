using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] private GameObject meteor;

    [SerializeField] private Vector3 zone;

    //[SerializeField] private float repeatTime = 10f;

    void Start(){

        InvokeRepeating("ApparitionMeteor", 3f, 10f);

    }

    void ApparitionMeteor()
    {

        GameObject instantiated = GameObject.Instantiate(meteor);
        instantiated.transform.position = new Vector3(
            Random.Range(transform.position.x - zone.x / 2, transform.position.x + zone.x / 2),
            Random.Range(transform.position.y - zone.y / 2, transform.position.y + zone.y / 2),
            Random.Range(transform.position.z - zone.z / 2, transform.position.z + zone.z / 2)
        );
         
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, zone);
    } 

}
