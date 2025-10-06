using TMPro;
using UnityEngine;

public class Coleta_itens : MonoBehaviour
{

    public TextMeshProUGUI texto;
    inventarioControla inventarioControla;
    public int contaPista;
    void Start()
    {
        inventarioControla = FindAnyObjectByType<inventarioControla>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {            
            Item item = collision.GetComponent<Item>();

            if (item != null)
            {
                bool itemAdicionado = inventarioControla.AddItem(collision.gameObject);

                if (itemAdicionado)
                {
                   // texto.text += $"Você tem {item.nome}\n";
                    Destroy(collision.gameObject);
                }
            }            
        }

        if (collision.gameObject.CompareTag("Pistas"))
        {
            Item item = collision.GetComponent<Item>();
            //texto.text += $"Você tem {item.nome}\n";
            Destroy(collision.gameObject);

            contaPista++;
            texto.text = $"{contaPista}";
        }
        
        if (collision.gameObject.CompareTag("Ursinho"))
        {
            Debug.Log("Conseguiu um urso de pelucia!");
            Destroy(collision.gameObject);
        }
            if (collision.gameObject.CompareTag("Pato"))
            {
                Destroy(collision.gameObject);
                Debug.Log("Conseguiu um pato de borracha!");
            }
            if (collision.gameObject.CompareTag("Bola"))
            {
                Destroy(collision.gameObject);
                Debug.Log("Conseguiu uma bola de futebol!");
            }
            if (collision.gameObject.CompareTag("Panela"))
            {
                Destroy(collision.gameObject);
                Debug.Log("Conseguiu uma panela de brinquedo!");
            }
            if (collision.gameObject.CompareTag("Boneca"))
            {
                Destroy(collision.gameObject);
                Debug.Log("Conseguiu a boneca de pano da Niara!");
            }
            if (collision.gameObject.CompareTag("Chave"))
            {
                Destroy(collision.gameObject);
                Debug.Log("Conseguiu uma chave!");
            }
            if (collision.gameObject.CompareTag("Cabra"))
            {
                Destroy(collision.gameObject);
                Debug.Log("Conseguiu um p� de cabra!");
            }
        }


}
