using System.Collections;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject aberta;             // GameObject que representa a porta aberta 
    public int idChave;                   // ID do item chave necessário para abrir a porta

    inventarioControla inventario;        // Referência ao inventário do jogador
    FalaBalao falaBalao;                  // Referência ao script que controla os balões de fala

    void Start()
    {
        if(aberta != null) aberta.SetActive(false);        
        falaBalao = FindAnyObjectByType<FalaBalao>();        // Busca o script FalaBalao na cena
        inventario = FindAnyObjectByType<inventarioControla>(); // Busca o inventário na cena
    }

    void OnTriggerEnter2D(Collider2D collision) // quando o jogador ativa a porta
    {
         if (collision.CompareTag("Player"))             // Verifica se o objeto é o jogador
        {
            if (inventario.verificarItemDestr(idChave))    // Verifica se o jogador possui a chave e a remove do inventário
            {
                if(aberta != null) aberta.SetActive(true);  
                gameObject.SetActive(false);                 // Desativa o collider para permitir passagem
            }
            else                            // Se o jogador não tiver a chave e a porta não estiver aberta
            {
                StartCoroutine(falaBalao.tempoFechar("Está trancada")); // Mostra mensagem de porta trancada
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)               // Dispara quando o jogador colide fisicamente com a porta
    {
        if (col.collider.CompareTag("Player"))             // Verifica se o objeto é o jogador
        {
            if (inventario.verificarItemDestr(idChave))    // Verifica se o jogador possui a chave e a remove do inventário
            {
                if(aberta != null) aberta.SetActive(true);  
                gameObject.SetActive(false);                 // Desativa o collider para permitir passagem
            }
            else                            // Se o jogador não tiver a chave e a porta não estiver aberta
            {
                StartCoroutine(falaBalao.tempoFechar("Está trancada")); // Mostra mensagem de porta trancada
            }

        }
    }
}