using UnityEngine;

public class TpPorta : MonoBehaviour
{
    public Transform tp;       // Transform para onde o jogador ser� teleportado

    void OnTriggerEnter2D(Collider2D other)   // Dispara quando algum objeto entra no collider deste objeto
    {
        if (other.CompareTag("Player"))      // Verifica se o objeto que entrou � o jogador
        {
            other.transform.position = tp.position; // Move o jogador instantaneamente para a posi��o do Transform definido
        }
    }
}
