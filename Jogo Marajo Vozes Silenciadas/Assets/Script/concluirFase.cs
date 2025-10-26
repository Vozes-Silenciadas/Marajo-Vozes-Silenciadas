using UnityEngine;
using UnityEngine.SceneManagement;

public class concluirFase : MonoBehaviour
{
    Coleta_itens pistass;             // Referência ao script que controla a coleta de pistas
    public FalaBalao fala;            // Referência ao script responsável por exibir falas ou balões de diálogo

    void Start()
    {
        fala = FindAnyObjectByType<FalaBalao>();     // Procura automaticamente o objeto que contém o script FalaBalao na cena
        pistass = FindAnyObjectByType<Coleta_itens>(); // Procura o script Coleta_itens (para saber quantas pistas foram coletadas)
    }

    void OnCollisionEnter2D(Collision2D collision)   // Detecta colisões físicas 
    {
        if (collision.collider.CompareTag("Player")) // Verifica se quem colidiu foi o jogador
        {
            if (pistass.contaPista >= 6)             // Se o jogador já coletou 6 ou mais pistas...
            {
                SceneManager.LoadScene(3);           // ...carrega a cena de índice 3 (provavelmente a próxima fase)
            }
            else                                     // Caso o jogador ainda não tenha todas as pistas
            {
                StartCoroutine(fala.tempoFechar("Preciso de mais pistas")); // Mostra mensagem dizendo que faltam pistas
                Debug.Log("sla");                   // Mensagem de teste
            }
        }
    }
}
