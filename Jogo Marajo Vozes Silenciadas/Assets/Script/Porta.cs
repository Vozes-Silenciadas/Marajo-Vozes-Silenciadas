using System.Collections;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Sprite portaAberta;
    public GameObject aberta;
    public GameObject balaoDeFala;
    public BoxCollider2D colissor;
    public int idChave;
    
    bool jaAbriu = false;
    inventarioControla inventario;
    SpriteRenderer spriteRenderer;
    FalaBalao falaBalao;

    void Start()
    {
        //colissor = GetComponent<BoxCollider2D>();
        falaBalao = FindAnyObjectByType<FalaBalao>();
        inventario = FindAnyObjectByType<inventarioControla>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (inventario.verificarItemDestr(idChave))
            {
                aberta.SetActive(true);
                jaAbriu = true;
            }
            else if (!jaAbriu)
            {
                StartCoroutine(falaBalao.tempoFechar("Está trancada, vou ver ao redor"));
            }

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            if (inventario.verificarItemDestr(idChave))
            {
                jaAbriu = true;
                colissor.enabled = false;
            }
            else if (!jaAbriu)
            {
                StartCoroutine(falaBalao.tempoFechar("Está trancada"));
            }

        }
    }


}
