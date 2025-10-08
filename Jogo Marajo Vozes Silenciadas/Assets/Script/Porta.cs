using UnityEngine;

public class Porta : MonoBehaviour
{
    public Sprite portaAberta;
    public SpriteRenderer spriteRenderer;
    public GameObject barraDeFerramenta;
    public BoxCollider2D colissor;
    public Mov jogador;
    public int idChave;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colissor = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        for (int i = 0; i < jogador.itensInve.Count;i++) {

            if (jogador.itensInve[i].ID == idChave)
            {
                spriteRenderer.sprite = portaAberta;
                colissor.enabled = false;
            }    
        }          
    }
   
}
