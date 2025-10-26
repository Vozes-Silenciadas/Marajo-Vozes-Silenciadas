using TMPro;
using UnityEngine;

public class Coleta_itens : MonoBehaviour
{

    public TextMeshProUGUI texto;     // Referência ao texto que mostra o número de pistas coletadas
    inventarioControla inventarioControla; // Referência ao script que controla o inventário
    public int contaPista;            // Contador de pistas coletadas
    public Mov jogador;               // Referência ao script do jogador

    void Start()
    {
        inventarioControla = FindAnyObjectByType<inventarioControla>(); // Encontra o objeto que controla o inventário
        jogador = GetComponent<Mov>();                                  // Pega o componente Mov do próprio jogador
    }

    private void OnTriggerEnter2D(Collider2D collision)                 // Detecta colisões com objetos que têm IsTrigger ativado
    {
        if (collision.gameObject.CompareTag("Item"))                   // Verifica se o objeto tem a tag "Item"
        {
            Item item = collision.GetComponent<Item>();                 // Pega o componente Item do objeto
            int bb = item.ID;                                           // Guarda o ID do item 

            if (item.nome == "Chave")                                   // Se o item se chama Chave
            {
                jogador.itensInve.Add(item);                            // ...adiciona o item diretamente ao inventário do jogador
            }

            if (item != null)                                           // Se o item existe
            {
                bool itemAdicionado = inventarioControla.AddItem(collision.gameObject); // Tenta adicionar o item ao inventário

                if (itemAdicionado)                                     // Se foi adicionado com sucesso...
                {
                    Destroy(collision.gameObject);                      // ...remove o item da cena
                }
            }
        }

        if (collision.gameObject.CompareTag("Pistas"))                  // Verifica se o objeto tem a tag Pistas
        {
            Item item = collision.GetComponent<Item>();                 // Pega o componente Item
            Destroy(collision.gameObject);                              // Destroi o objeto coletado

            contaPista++;                                               // Incrementa o contador de pistas
            texto.text = $"{contaPista}";                               // Atualiza o texto na tela com o número de pistas
        }
    }
}
