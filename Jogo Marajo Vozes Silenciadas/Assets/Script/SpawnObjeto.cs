using System.Collections;
using UnityEngine;

public class SpawnObjeto : MonoBehaviour
{
    public GameObject[] objetos;        // Array de prefabs de objetos que podem ser spawnados
    public Transform[] spawnPoints;     // Array de pontos de spawn onde os objetos podem aparecer

    float tempo;                        // Contador de tempo para controlar o intervalo de spawn

    void Update()
    {
        if (tempo > 0)                   // Se ainda não chegou o tempo para spawn
        {
            tempo -= Time.deltaTime;     // Subtrai o tempo passado desde o último frame
        }
        else                             // Quando o tempo chega a zero
        {
            int indexP = Random.Range(0, spawnPoints.Length); // Escolhe aleatoriamente um ponto de spawn
            int indexO = Random.Range(0, objetos.Length);     // Escolhe aleatoriamente um objeto do array

            Instantiate(objetos[indexO], spawnPoints[indexP].position, Quaternion.identity); // Cria o objeto no ponto escolhido

            tempo = Random.Range(2, 4);    // Reseta o contador de tempo com um valor aleatório entre 2 e 4 segundos
        }
    }
}
