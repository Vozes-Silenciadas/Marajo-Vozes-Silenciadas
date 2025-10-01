using UnityEngine;

public class visaoInimigo : MonoBehaviour
{
    
    [SerializeField] Transform jogador;
    float velo = 1.05f;
    Vector3 posicaoInical;
    [SerializeField] bool detectado = false;
    Rigidbody2D rb;
    bool emPatrulha;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoInical = transform.position;
    }

    void Update()
    {
        if (detectado)
        {
            Vector2 direcao = (jogador.position - transform.position).normalized;
            rb.linearVelocity = direcao * velo;
        }
        else if (!detectado)
        {
            float distacia = Vector2.Distance(transform.position, posicaoInical);

            if (distacia > 0.05f)
            {
                Vector2 voltar = (posicaoInical - transform.position).normalized;
                rb.linearVelocity = voltar * velo;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                emPatrulha = true;
            }

        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("E achei");
            jogador = other.transform;
            detectado = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            detectado = false;
            jogador = null;
        }
    }
}
