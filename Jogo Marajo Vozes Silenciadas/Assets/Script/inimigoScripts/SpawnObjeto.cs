using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObjeto : MonoBehaviour
{
    public GameObject[] objetos;        // Array de prefabs de objetos que podem ser spawnados
    public Transform[] spawnPoints;     // Array de pontos de spawn onde os objetos podem aparecer

    float tempo = 60;                        // Contador de tempo para controlar o intervalo de spawn

    void Start()
    { 
        // Inicia o processo de spawn de objetos
        Invoke("EncerrarFase", tempo);
        InvokeRepeating("CriarObjeto", 1f, 1.5f);
        InvokeRepeating("CriarObjeto", 1f, 1.5f);
    }
    private void Update()
    {
        // Atualiza o contador de tempo, quando acabar encerra a fase
        tempo -= Time.deltaTime;
        if (tempo <= 0)
        {
            EncerrarFase();
        }
    }
    void CriarObjeto()
    {
        int indexP = Random.Range(0, spawnPoints.Length); // Escolhe aleatoriamente um ponto de spawn
        int indexO = Random.Range(0, objetos.Length);     // Escolhe aleatoriamente um objeto do array

        Instantiate(objetos[indexO], spawnPoints[indexP].position, Quaternion.identity); // Cria o objeto no ponto escolhido
    }

    void EncerrarFase()
    {
        CancelInvoke("CriarObjeto");
        CancelInvoke("CriarObjeto");
    }
}
