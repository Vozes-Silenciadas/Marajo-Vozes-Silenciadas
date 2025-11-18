using System.Collections.Generic;
using UnityEngine;


public class aliadoSegue : MonoBehaviour
{
    GameObject jogador;
    public float toleranca;

    Queue<Vector2> gravado = new Queue<Vector2>(); // Fila para armazenar as posições do jogador

    Mov moviPlayer;
    SpriteRenderer sprite;
    Animator animator;
    bool resgatado;
    static public int qtdResgatados;


    void Start()
    {
        moviPlayer = FindAnyObjectByType<Mov>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moviCrianca();
    }

    // ---------------------- Movimento da Criança Seguindo o Jogador ------------------ //
    private void moviCrianca()
    {
        if (resgatado)
        {
            if (moviPlayer.estaMovendo()) // Grava a posição do jogador apenas se ele estiver se movendo
            {
                gravado.Enqueue(jogador.transform.position);
            }

            if (gravado.Count > 0) // Verifica se há posições gravadas para seguir
            {
                float distancia = Vector2.Distance(gravado.Peek(), jogador.transform.position); // Calcula a distância entre a próxima posição gravada e a posição atual do jogador
                if (distancia > toleranca) // Move a criança apenas se a distância for maior que a tolerância
                {
                    Vector2 vector = gravado.Dequeue();

                    animator.SetBool("estaAndando", true);

                    // Define a direção da animação e a escala com base na posição da criança
                    if ((vector.x - transform.position.x) < 0)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if ((vector.x - transform.position.x) > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    
                    animator.SetFloat("dirX", vector.x - transform.position.x);
                    animator.SetFloat("dirY", vector.y - transform.position.y);

                    transform.position = vector;
                } else
                {
                    animator.SetBool("estaAndando",false);
                }
            }

            // Ajusta a ordem de renderização com base na posição y do jogador e da criança
            if (transform.position.y < jogador.transform.position.y)
            {
                sprite.sortingOrder = 3;
                sprite.sortingLayerName = "cima";
            }
            else
            {
                sprite.sortingOrder = 2;
                sprite.sortingLayerName = "Default";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //  Verifica se o jogador colidiu com a criança para resgatá-la
        if (collision.CompareTag("Player"))
        {
            if (!resgatado)
            {
                resgatado = true;
                jogador = collision.gameObject;
            }
        }
    }
    
    public void ChegouNoBarco()
    {
        // Verifica se a criança chegou ao barco para ser resgatada
        if (resgatado)
        {
            resgatado = false;
            qtdResgatados++;
            gameObject.SetActive(false);
            gravado.Clear();
        }
    }

    public bool niaraChegouNoBarco()
    {
        if (resgatado)
        {
            resgatado = false;            
            gameObject.SetActive(false);
            gravado.Clear();
            return true;
        }
        return false;
    }
}
