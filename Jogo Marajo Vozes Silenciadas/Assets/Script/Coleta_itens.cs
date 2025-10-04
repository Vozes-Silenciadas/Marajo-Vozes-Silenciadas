using TMPro;
using UnityEngine;

public class Coleta_itens : MonoBehaviour
{

    public TextMeshProUGUI texto;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ursinho"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem urso de pelucia!";
            Debug.Log("Conseguiu um urso de pelucia!");
        }
        if (collision.gameObject.CompareTag("Pato"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem pato de borracha!";
            Debug.Log("Conseguiu um pato de borracha!");
        }
        if (collision.gameObject.CompareTag("Bola"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem uma bola de futebol!";
            Debug.Log("Conseguiu uma bola de futebol!");
        }
        if (collision.gameObject.CompareTag("Panela"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem uma panela de brinquedo!";
            Debug.Log("Conseguiu uma panela de brinquedo!");
        }
        if (collision.gameObject.CompareTag("Boneca"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem a boneca de pano da Niara!";
            Debug.Log("Conseguiu a boneca de pano da Niara!");
        }
        if (collision.gameObject.CompareTag("Chave"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem uma chave!";
            Debug.Log("Conseguiu uma chave!");
        }
        if (collision.gameObject.CompareTag("Cabra"))
        {
            Destroy(collision.gameObject);
            texto.text += $"\nvocê tem um pé de cabra";
            Debug.Log("Conseguiu um p� de cabra!");
        }
    }
}
