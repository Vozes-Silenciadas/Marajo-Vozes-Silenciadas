using UnityEngine;
using UnityEngine.SceneManagement;

public class concluirFase : MonoBehaviour
{
    Coleta_itens pistass;             // Refer�ncia ao script que controla a coleta de pistas
    public FalaBalao fala;            // Refer�ncia ao script respons�vel por exibir falas ou bal�es de di�logo

    void Start()
    {
        fala = FindAnyObjectByType<FalaBalao>();     // Procura automaticamente o objeto que cont�m o script FalaBalao na cena
        pistass = FindAnyObjectByType<Coleta_itens>(); // Procura o script Coleta_itens (para saber quantas pistas foram coletadas)
    }

    void OnCollisionEnter2D(Collision2D collision)   // Detecta colis�es f�sicas 
    {
        if (collision.collider.CompareTag("Player")) // Verifica se quem colidiu foi o jogador
        {
            if (pistass.contaPista >= 6)             // Se o jogador j� coletou 6 ou mais pistas...
            {
                SceneManager.LoadScene(3);           // ...carrega a cena de �ndice 3 (provavelmente a pr�xima fase)
            }
            else                                     // Caso o jogador ainda n�o tenha todas as pistas
            {
                StartCoroutine(fala.tempoFechar("Preciso de mais pistas")); // Mostra mensagem dizendo que faltam pistas
            }
        }
    }
}
