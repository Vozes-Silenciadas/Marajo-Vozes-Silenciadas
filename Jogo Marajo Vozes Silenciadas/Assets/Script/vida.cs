using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public int vidaStat;                   // Quantidade atual de vida do jogador
    public int cena;                        // Índice da cena a ser carregada quando morrer
    public GameObject[] coracoes;           // Array de corações na UI representando a vida

    void Start()
    {
        vidaStat = 3;                       // Inicializa a vida do jogador com 3
    }

    void FixedUpdate()
    {
        if (vidaStat <= 0)                  // Se a vida acabar
        {
            SceneManager.LoadScene(cena);   // Carrega a cena definida no índice cena
        }
    }

    public void PerderVida()                 // Método chamado para perder uma vida
    {
        Destroy(coracoes[vidaStat - 1]);       // Destroi o coração correspondente à vida atual
    }
}