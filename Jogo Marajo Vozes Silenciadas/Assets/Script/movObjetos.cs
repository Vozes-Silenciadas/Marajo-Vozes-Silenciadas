using UnityEngine;

public class movObjetos : MonoBehaviour
{

    public float velocidade = 2f;       // Velocidade com que o objeto se move para baixo
    public float pontoParaDestruir;     // Posição Y em que o objeto será destruído

    void Update()
    {
        transform.Translate(Vector2.down * velocidade * Time.deltaTime); // Move o objeto para baixo a cada frame

        if (transform.position.y < pontoParaDestruir)                    // Se o objeto passar do limite Y definido
        {
            Destroy(this.gameObject);                                     // Destrói o objeto para não ficar na cena
        }
    }
}