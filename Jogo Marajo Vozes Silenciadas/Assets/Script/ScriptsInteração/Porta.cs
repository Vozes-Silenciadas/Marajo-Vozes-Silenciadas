using System.Collections;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Sprite portaAberta;            // Sprite que representa a porta aberta
    public GameObject aberta;             // GameObject que representa a porta aberta 
    public BoxCollider2D colissor;        // Collider da porta para impedir ou permitir passagem
    public int idChave;                   // ID do item chave necessário para abrir a porta

    bool jaAbriu = false;                 // Verifica se a porta já foi aberta
    inventarioControla inventario;        // Referência ao inventário do jogador
    SpriteRenderer spriteRenderer;        // Referência ao SpriteRenderer 
    FalaBalao falaBalao;                  // Referência ao script que controla os balões de fala

    void Start()
    {
        colissor = GetComponent<BoxCollider2D>(); // Caso queira pegar automaticamente o collider
        falaBalao = FindAnyObjectByType<FalaBalao>();        // Busca o script FalaBalao na cena
        inventario = FindAnyObjectByType<inventarioControla>(); // Busca o inventário na cena
    }

    void OnTriggerEnter2D(Collider2D col)                    // Dispara quando o jogador entra na área da porta
    {
        if (col.CompareTag("Player"))                        // Verifica se o objeto é o jogador
        {
            if (inventario.verificarItemDestr(idChave))     // Verifica se o jogador possui a chave e a remove do inventário
            {
                aberta.SetActive(true);                     // Ativa a porta aberta
                jaAbriu = true;                             // Marca a porta como aberta
            }
            else if (!jaAbriu)                              // Se o jogador não tiver a chave e a porta não estiver aberta
            {
                StartCoroutine(falaBalao.tempoFechar("Está trancada, vou ver ao redor")); // Mostra mensagem
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)               // Dispara quando o jogador colide fisicamente com a porta
    {
        if (col.collider.CompareTag("Player"))             // Verifica se o objeto é o jogador
        {
            if (inventario.verificarItemDestr(idChave))    // Verifica se o jogador possui a chave e a remove do inventário
            {
                jaAbriu = true;                             // Marca a porta como aberta
                colissor.enabled = false;
                gameObject.SetActive(false);                 // Desativa o collider para permitir passagem
            }
            else if (!jaAbriu)                              // Se o jogador não tiver a chave e a porta não estiver aberta
            {
                StartCoroutine(falaBalao.tempoFechar("Está trancada")); // Mostra mensagem de porta trancada
            }

        }
    }
}