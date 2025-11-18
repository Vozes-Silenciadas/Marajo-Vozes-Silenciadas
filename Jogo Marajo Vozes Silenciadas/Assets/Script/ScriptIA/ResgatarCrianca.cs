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
        script.enabled = false; // Desativa o script de seguir no início
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica se o jogador colidiu com a criança
        {
            switch (idCrianca) // Verifica o ID da criança para determinar a ação correta
            {
                case 1: // Criança entrega um item específico
                    if (!resgatado)
                    {
                        if (inventario.AddItem(item))
                        {                            
                            script.enabled = true;
                            resgatado = true;                    
                        }
                    }
                    break;

                case 2: // Criança exige um item específico para ser resgatada
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
