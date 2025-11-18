using TMPro;
using UnityEngine;

public class Coleta_itens : MonoBehaviour
{

    public TextMeshProUGUI texto;     // Referencia ao texto que mostra o numero de pistas coletadas
    inventarioControla inventarioControla; // Referencia ao script que controla o inventario
    public int contaPista;            // Contador de pistas coletadas
    public Mov jogador;               // Refer�ncia ao script do jogador
    FalaBalao fala;

    void Start()
    {
        inventarioControla = FindAnyObjectByType<inventarioControla>(); // Encontra o objeto que controla o inventario
        jogador = GetComponent<Mov>();                                  // Pega o componente Mov do proprio jogador
        fala = FindAnyObjectByType<FalaBalao>();
    }

    private void OnTriggerEnter2D(Collider2D collision)                 // Detecta colisoes com objetos que tem IsTrigger ativado
    {
        if (collision.gameObject.CompareTag("Item"))                   // Verifica se o objeto tem a tag "Item"
        {
            Item item = collision.GetComponent<Item>();                 // Pega o componente Item do objeto
            int bb = item.ID;                                           // Guarda o ID do item 

            if (item.nome == "Chave")                                   // Se o item se chama Chave
            {
                jogador.itensInve.Add(item);                            // ...adiciona o item diretamente ao inventario do jogador
            }

            if (item != null)                                           // Se o item existe
            {
                bool itemAdicionado = inventarioControla.AddItem(collision.gameObject); // Tenta adicionar o item ao inventario

                if (itemAdicionado)                                     // Se foi adicionado com sucesso
                {
                    Destroy(collision.gameObject);                      // remove o item da cena
                }
            }
        }

        if (collision.gameObject.CompareTag("Pistas"))                  // Verifica se o objeto tem a tag Pistas
        {
            Item item = collision.GetComponent<Item>();                 // Pega o componente Item
            Destroy(collision.gameObject);                              // Destroi o objeto coletado

            contaPista++;                                               // Incrementa o contador de pistas
            texto.text = $"{contaPista}";                               // Atualiza o texto na tela com o n�mero de pistas

            if (contaPista >= 6)
            {
                StartCoroutine(fala.tempoFechar("Encontrei todas as pistas, hora de voltar"));
            }
        }
    }
}
