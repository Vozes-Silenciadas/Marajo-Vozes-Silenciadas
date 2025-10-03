using UnityEngine;

public class Coleta_itens : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ursinho"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Conseguiu um urso de pelucia!");
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
            Debug.Log("Conseguiu um pé de cabra!");
        }
    }
}
