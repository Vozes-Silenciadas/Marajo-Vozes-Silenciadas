using TMPro;
using UnityEngine;

public class Coleta_itens : MonoBehaviour
{

    public TextMeshProUGUI texto;
    inventarioControla inventarioControla;
    public int contaPista;
    public Mov jogador;
    
    void Start()
    {
        inventarioControla = FindAnyObjectByType<inventarioControla>();
        jogador = GetComponent<Mov>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {            
            Item item = collision.GetComponent<Item>();
            int bb = item.ID;
            
            if (item.nome == "Chave")
            {
                jogador.itensInve.Add(item);
            }

            if (item != null)
            {
                bool itemAdicionado = inventarioControla.AddItem(collision.gameObject);

                if (itemAdicionado)
                {
                    Destroy(collision.gameObject);
                }
            }            
        }

        if (collision.gameObject.CompareTag("Pistas"))
        {
            Item item = collision.GetComponent<Item>();
            Destroy(collision.gameObject);

            contaPista++;
            texto.text = $"{contaPista}";
        }        
        
    }


}
