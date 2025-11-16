using TMPro;
using UnityEngine;

public class Coleta_itens : MonoBehaviour
{

    public TextMeshProUGUI texto;     // Refer�ncia ao texto que mostra o n�mero de pistas coletadas
    inventarioControla inventarioControla; // Refer�ncia ao script que controla o invent�rio
    public int contaPista;            // Contador de pistas coletadas
    public Mov jogador;               // Refer�ncia ao script do jogador
    FalaBalao fala;

    void Start()
    {
        inventarioControla = FindAnyObjectByType<inventarioControla>(); // Encontra o objeto que controla o invent�rio
        jogador = GetComponent<Mov>();                                  // Pega o componente Mov do pr�prio jogador
        fala = FindAnyObjectByType<FalaBalao>();
    }

    private void OnTriggerEnter2D(Collider2D collision)                 // Detecta colis�es com objetos que t�m IsTrigger ativado
    {
        if (collision.gameObject.CompareTag("Item"))                   // Verifica se o objeto tem a tag "Item"
        {
            Item item = collision.GetComponent<Item>();                 // Pega o componente Item do objeto
            int bb = item.ID;                                           // Guarda o ID do item 

            if (item.nome == "Chave")                                   // Se o item se chama Chave
            {
                jogador.itensInve.Add(item);                            // ...adiciona o item diretamente ao invent�rio do jogador
            }

            if (item != null)                                           // Se o item existe
            {
                bool itemAdicionado = inventarioControla.AddItem(collision.gameObject); // Tenta adicionar o item ao invent�rio

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
            texto.text = $"{contaPista}";                               // Atualiza o texto na tela com o n�mero de pistas

            if (contaPista >= 6)
            {
                StartCoroutine(fala.tempoFechar("Encontrei todas as pistas, hora de voltar"));
            }
        }
    }
}
