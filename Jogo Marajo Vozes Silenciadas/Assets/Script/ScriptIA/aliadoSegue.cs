using System.Collections.Generic;
using UnityEngine;


public class aliadoSegue : MonoBehaviour
{
    GameObject jogador;
    public float toleranca;

    Queue<Vector2> gravado = new Queue<Vector2>();

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

    private void moviCrianca()
    {
        if (resgatado)
        {
            if (moviPlayer.estaMovendo())
            {
                gravado.Enqueue(jogador.transform.position);
            }

            if (gravado.Count > 0)
            {
                float distancia = Vector2.Distance(gravado.Peek(), jogador.transform.position);
                if (distancia > toleranca)
                {
                    Vector2 vector = gravado.Dequeue();

                    animator.SetBool("estaAndando", true);

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
        if (resgatado)
        {
            resgatado = false;
            qtdResgatados++;
            gameObject.SetActive(false);
            gravado.Clear();
        }
    }
}
