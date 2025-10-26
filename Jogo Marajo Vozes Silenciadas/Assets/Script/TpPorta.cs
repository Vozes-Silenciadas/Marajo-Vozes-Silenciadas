using UnityEngine;

public class TpPorta : MonoBehaviour
{
    public int cena;           // Índice de cena (não usado diretamente aqui, mas poderia servir para trocar de cena)
    public Transform tp;       // Transform para onde o jogador será teleportado

    void OnTriggerEnter2D(Collider2D other)   // Dispara quando algum objeto entra no collider deste objeto
    {
        if (other.CompareTag("Player"))      // Verifica se o objeto que entrou é o jogador
        {
            other.transform.position = tp.position; // Move o jogador instantaneamente para a posição do Transform definido
        }
    }
}
