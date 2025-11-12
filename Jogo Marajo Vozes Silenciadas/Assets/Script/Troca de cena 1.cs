using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocadecena1 : MonoBehaviour
{
    public void Cena()                                // M�todo para carregar a cena Fase1
    {
        SceneManager.LoadScene("Fase1");             // Carrega a cena pelo nome
    }

    void Start()                                     // Start � chamado uma vez quando o objeto � inicializado
    {
        Invoke("Cena",33.5f);
    }

}
