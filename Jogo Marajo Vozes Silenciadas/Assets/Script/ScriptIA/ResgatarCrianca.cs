using UnityEngine;

public class ResgatarCrianca : MonoBehaviour
{

    public MonoBehaviour script;
    inventarioControla inventario;
    public GameObject item;
    public int idCrianca;
    FalaBalao fala;
    bool resgatado;
    void Start()
    {
        inventario = FindAnyObjectByType<inventarioControla>();
        fala = FindAnyObjectByType<FalaBalao>();
        script.enabled = false;
    }
/*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            switch (idCrianca)
            {
                case 1:
                    inventario.AddItem(item);
                    script.enabled = true;
                    break;

                case 2:
                    if (inventario.verificarItemDestr(4))
                    {
                        script.enabled = true;
                    }
                    else
                    {
                        StartCoroutine(fala.tempoFechar("Quero meu brinquedo"));
                    }
                    break;
            }
        }
    }
*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (idCrianca)
            {
                case 1:
                    if (!resgatado)
                    {
                        if (inventario.AddItem(item))
                        {                            
                            script.enabled = true;
                            resgatado = true;                    
                        }
                    }
                    break;

                case 2:
                    if (inventario.verificarItemDestr(4))
                    {
                        script.enabled = true;
                        resgatado = true;
                    }
                    else if(!resgatado)
                    {
                        StartCoroutine(fala.tempoFechar("Quero meu brinquedo"));
                    }
                    break;
            }
        }   
    }
}
