using System.Collections;
using UnityEngine;

public class SpawnObjeto : MonoBehaviour
{
    public GameObject[] objetos;
    public Transform[] spawnPoints;

    float tempo;

    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
        }
        else
        {
            int indexP = Random.Range(0, spawnPoints.Length);
            int indexO = Random.Range(0, objetos.Length);

            Instantiate(objetos[indexO], spawnPoints[indexP].position, Quaternion.identity);

            tempo = Random.Range(2,4);           
        }
            
    }

}
