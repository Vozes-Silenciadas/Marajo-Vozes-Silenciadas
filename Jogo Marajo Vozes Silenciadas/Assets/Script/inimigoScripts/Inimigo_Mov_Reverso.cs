using UnityEngine;

public class Inimigo_Mov_Reverso : MonoBehaviour
{
    // Direções do inimigo X e Y
    public float dirX;
    public float dirY;

    Rigidbody2D rb; // Corpo rígido do inimigo
    public Transform[] pontosPatrulha; // Vetor de pontos que o inimigo vai passar
    public CampoVisao campoVisao; // Armazena o campo de visao

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = pontosPatrulha[0].position; // Colocar o inimigo no ponto inicial 
        dirX = -1; // Direção X inicial
    }

    void Update()
    {        
        MovimentacaoInimigo();
        campoVisao.DirecaoInimigo(dirX, dirY); // Mudar a direcao do campo de visao
    }

    // ------------------------------Movimentação para IA do Inimigo------------------------//
    private void MovimentacaoInimigo()
    {
        if (transform.localPosition.x < pontosPatrulha[2].localPosition.x)
        {
            dirX = 0;
            dirY = 1;
            transform.rotation = Quaternion.Euler(dirX, dirY, 180);
        }
        if (transform.localPosition.y > pontosPatrulha[1].localPosition.y)
        {
            dirX = 1;
            dirY = 0;
            transform.rotation = Quaternion.Euler(dirX, dirY, 90);
        }
        if (transform.localPosition.x > pontosPatrulha[4].localPosition.x)
        {
            dirX = 0;
            dirY = -1;
            transform.rotation = Quaternion.Euler(dirX, dirY, 0);
        }
        if (transform.localPosition.x > pontosPatrulha[0].localPosition.x && transform.localPosition.y > pontosPatrulha[0].localPosition.y)
        {
            dirX = -1;
            dirY = 0;
            transform.rotation = Quaternion.Euler(dirX, dirY, -90);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX, dirY);
    }
}
