using UnityEngine;

public class visaoInimigo : MonoBehaviour
{
    [SerializeField] Transform jogador;       // Referência ao transform do jogador
    float velo = 1.05f;                        // Velocidade do inimigo
    Vector3 posicaoInical;                     // Posição inicial do inimigo
    [SerializeField] bool detectado = false;   // Se o jogador foi detectado
    Rigidbody2D rb;                            // Rigidbody do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();      // Pega o Rigidbody2D do inimigo
        posicaoInical = transform.position;    // Guarda a posição inicial
    }

    void Update()
    {
        if (detectado)                          // Se o jogador foi detectado
        {
            Vector2 direcao = (jogador.position - transform.position).normalized; // Calcula direção até o jogador
            rb.linearVelocity = direcao * velo; // Move o inimigo em direção ao jogador
        }
        else if (!detectado)                    // Se o jogador não foi detectado
        {
            float distacia = Vector2.Distance(transform.position, posicaoInical); // Distância até a posição inicial

            if (distacia > 0.05f)               // Se estiver distante do ponto inicial
            {
                Vector2 voltar = (posicaoInical - transform.position).normalized; // Direção de volta
                rb.linearVelocity = voltar * velo; // Move de volta para a posição inicial
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // Para o movimento quando chega no ponto inicial
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))         // Se colidir com o jogador
        {
            Debug.Log("E achei");               // Mensagem de debug
            jogador = other.transform;          // Guarda referência do jogador
            detectado = true;                   // Marca como detectado
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))         // Se o jogador sair da área de detecção
        {
            detectado = false;                  // Marca como não detectado
            jogador = null;                     // Limpa a referência do jogador
        }
    }
}
