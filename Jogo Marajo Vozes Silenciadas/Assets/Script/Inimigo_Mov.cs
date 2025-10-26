using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class Inimigo_Mov : MonoBehaviour
{
    public float dirX;                       // Direção horizontal do inimigo
    public float dirY;                       // Direção vertical do inimigo
    float dirZ;                              // Variável Z (não utilizada neste script)
    Rigidbody2D rb;                          // Referência ao Rigidbody2D para movimentação
    public Transform[] pontosPatrulha;       // Pontos pelos quais o inimigo vai patrulhar
    public CampoVisao sla;                   // Referência ao script que controla o campo de visão do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Pega o Rigidbody2D do inimigo

        transform.position = pontosPatrulha[0].position; // Posiciona o inimigo no primeiro ponto de patrulha
        dirX = 1f;                             // Define a direção inicial do movimento (para a direita)
    }

    void Update()
    {
        // Se passar do segundo ponto (pontoPatrulha[1]) na horizontal
        if (transform.localPosition.x > pontosPatrulha[1].localPosition.x)
        {
            dirX = 0f;                         // Para movimento horizontal
            dirY = 1f;                         // Começa a subir
            transform.rotation = Quaternion.Euler(dirX, dirY, 180); // Rotaciona o inimigo
        }

        // Se passar do terceiro ponto (pontoPatrulha[2]) na vertical
        if (transform.localPosition.y > pontosPatrulha[2].localPosition.y)
        {
            dirY = 0f;                         // Para movimento vertical
            dirX = -1f;                        // Começa a se mover para a esquerda
            transform.rotation = Quaternion.Euler(dirX, dirY, -90); // Rotaciona o inimigo
        }

        // Se passar do quarto ponto (pontoPatrulha[3]) na horizontal
        if (transform.localPosition.x < pontosPatrulha[3].localPosition.x)
        {
            dirX = 0f;                         // Para movimento horizontal
            dirY = -1f;                        // Começa a descer
            transform.rotation = Quaternion.Euler(dirX, dirY, 0); // Rotaciona o inimigo
        }

        // Se retornar ao ponto inicial (pontoPatrulha[0])
        if (transform.localPosition.x < pontosPatrulha[0].localPosition.x && transform.localPosition.y < pontosPatrulha[0].localPosition.y)
        {
            dirX = 1f;                         // Começa a se mover para a direita
            dirY = 0f;                         // Sem movimento vertical
            transform.rotation = Quaternion.Euler(dirX, dirY, 90); // Rotaciona o inimigo
        }

        sla.DirecaoInimigo(dirX, dirY);       // Atualiza a direção do inimigo no script de campo de visão
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX, dirY); // Aplica a velocidade ao Rigidbody2D (movimento físico)
    }
}