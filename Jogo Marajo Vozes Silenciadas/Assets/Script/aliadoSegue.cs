using System.Collections.Generic;
using UnityEngine;


public class aliadoSegue : MonoBehaviour
{
    GameObject jogador;
    public float toleranca;

    Queue<Vector2> gravado = new Queue<Vector2>();

    Mov moviPlayer;
    bool resgatado;

    void Start()
    {
        moviPlayer = FindAnyObjectByType<Mov>();
    }

    void FixedUpdate()
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
                    transform.position = gravado.Dequeue();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            resgatado = true;
            jogador = collision.gameObject;
        }
    }
}
