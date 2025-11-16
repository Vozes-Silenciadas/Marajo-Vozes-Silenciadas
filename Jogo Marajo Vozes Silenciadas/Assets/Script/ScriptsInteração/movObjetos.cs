using System.Collections;
using UnityEngine;

public class movObjetos : MonoBehaviour
{

    public float velocidade = 2f;       // Velocidade com que o objeto se move para baixo
    public float pontoParaDestruir;     // Posi��o Y em que o objeto ser� destru�do
    vida vida;

    void Start()
    {
        vida = FindAnyObjectByType<vida>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * velocidade * Time.deltaTime); // Move o objeto para baixo a cada frame

        if (transform.position.y < pontoParaDestruir)                    // Se o objeto passar do limite Y definido
        {
            Destroy(this.gameObject);                                     // Destr�i o objeto para n�o ficar na cena
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        {
            vida.PerderVida();
            StartCoroutine(pisca(collision.gameObject));
        }
    }

    IEnumerator pisca(GameObject jogador)
    {        
        SpriteRenderer sprite = jogador.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5;i++)
        {
            sprite.color = Color.white;    
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.2f);        
        }
    }
}