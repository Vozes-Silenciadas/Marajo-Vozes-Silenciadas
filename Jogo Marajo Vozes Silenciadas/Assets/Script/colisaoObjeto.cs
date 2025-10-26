using UnityEngine;

public class colisaoObjeto : MonoBehaviour
{
    vida vida;                                  // Referência ao script vida

    void Start()
    {
        vida = FindAnyObjectByType<vida>();    // Busca a instância do script 'vida' na cena
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objeto"))    // Se o objeto colidido tiver a tag "Objeto"
        {
            vida.vidaStat--;                   // Diminui a vida atual do jogador em 1
            vida.PerderVida();                 // Chama o método que destrói o coração correspondente
            Debug.Log("Vida Atual: " + vida.vidaStat); // Mostra no console a vida atual
        }
    }
}
