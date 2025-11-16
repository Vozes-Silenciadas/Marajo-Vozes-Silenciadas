using UnityEngine;

public class puzzleFase4 : MonoBehaviour
{
    public GameObject aberta;             // GameObject que representa a porta aberta 

    inventarioControla inventario;        // Referência ao inventário do jogador
    FalaBalao falaBalao; 

    void Start()
    {
        aberta.SetActive(false);        
        falaBalao = FindAnyObjectByType<FalaBalao>();        // Busca o script FalaBalao na cena
        inventario = FindAnyObjectByType<inventarioControla>(); // Busca o inventário na cena
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.collider.CompareTag("Player"))             // Verifica se o objeto é o jogador
        {
            if (inventario.verificarItem(1) && inventario.verificarItem(2) && inventario.verificarItem(3))    // Verifica se o jogador possui a chave e a remove do inventário
            {
                aberta.SetActive(true);  
                gameObject.SetActive(false);                 // Desativa o collider para permitir passagem
            }
            else                            // Se o jogador não tiver a chave e a porta não estiver aberta
            {
                StartCoroutine(falaBalao.tempoFechar("Essa porta abre diferente")); // Mostra mensagem de porta trancada
            }
        }
    }
}
