using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocadecena1 : MonoBehaviour
{
    public void Cena()                                // Método para carregar a cena Fase1
    {
        SceneManager.LoadScene("Fase1");             // Carrega a cena pelo nome
    }

    float Tempo;                                      // Contador de tempo do jogo
    public TextMeshProUGUI texto;                     // Texto na UI que mostrará o tempo

    void Start()                                     // Start é chamado uma vez quando o objeto é inicializado
    {
        Tempo = 60;                                  // Define o tempo inicial como 60 segundos
    }

    void Update()                                    // Update é chamado a cada frame
    {
        Tempo -= Time.deltaTime;                     // Subtrai o tempo passado desde o último frame
        texto.text = $"Tempo: {Tempo.ToString("F0")}"; // Atualiza o texto da UI mostrando o tempo arredondado

        if (Tempo < 0)                               // Se o tempo acabar
        {
            Cena();                                  // Chama o método para carregar a cena Fase1
        }
    }
}
