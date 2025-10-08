using UnityEngine;

public class Porta : MonoBehaviour
{
    public Sprite portaAberta;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D colissor;
    public int idChave;
    public inventarioControla inventario;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colissor = GetComponent<BoxCollider2D>();
        inventario = FindAnyObjectByType<inventarioControla>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            if (inventario.verificarItemDestr(idChave))
            {
                spriteRenderer.sprite = portaAberta;
                colissor.enabled = false;
            }
            else
            {
                Debug.Log("Precisa de Chave Certa");
            }
                
        }
    }
   
}
