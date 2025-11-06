using UnityEngine;
public class Inimigo_Mov : MonoBehaviour
{
    public float dirX;                       // Dire��o horizontal do inimigo
    public float dirY;                       // Dire��o vertical do inimigo
    float dirZ;                              // Vari�vel Z (n�o utilizada neste script)
    Rigidbody2D rb;                          // Refer�ncia ao Rigidbody2D para movimenta��o
    public Transform[] pontosPatrulha;       // Pontos pelos quais o inimigo vai patrulhar
    public CampoVisao sla;                   // Refer�ncia ao script que controla o campo de vis�o do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Pega o Rigidbody2D do inimigo

        transform.position = pontosPatrulha[0].position; // Posiciona o inimigo no primeiro ponto de patrulha
        dirX = 1f;                             // Define a dire��o inicial do movimento (para a direita)
    }

    void Update()
    {
        // Se passar do segundo ponto (pontoPatrulha[1]) na horizontal
        if (transform.localPosition.x > pontosPatrulha[1].localPosition.x)
        {
            dirX = 0f;                         // Para movimento horizontal
            dirY = 1f;                         // Come�a a subir
            transform.rotation = Quaternion.Euler(dirX, dirY, 180); // Rotaciona o inimigo
        }

        // Se passar do terceiro ponto (pontoPatrulha[2]) na vertical
        if (transform.localPosition.y > pontosPatrulha[2].localPosition.y)
        {
            dirY = 0f;                         // Para movimento vertical
            dirX = -1f;                        // Come�a a se mover para a esquerda
            transform.rotation = Quaternion.Euler(dirX, dirY, -90); // Rotaciona o inimigo
        }

        // Se passar do quarto ponto (pontoPatrulha[3]) na horizontal
        if (transform.localPosition.x < pontosPatrulha[3].localPosition.x)
        {
            dirX = 0f;                         // Para movimento horizontal
            dirY = -1f;                        // Come�a a descer
            transform.rotation = Quaternion.Euler(dirX, dirY, 0); // Rotaciona o inimigo
        }

        // Se retornar ao ponto inicial (pontoPatrulha[0])
        if (transform.localPosition.x < pontosPatrulha[0].localPosition.x && transform.localPosition.y < pontosPatrulha[0].localPosition.y)
        {
            dirX = 1f;                         // Come�a a se mover para a direita
            dirY = 0f;                         // Sem movimento vertical
            transform.rotation = Quaternion.Euler(dirX, dirY, 90); // Rotaciona o inimigo
        }

        sla.DirecaoInimigo(dirX, dirY);       // Atualiza a dire��o do inimigo no script de campo de vis�o
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX, dirY); // Aplica a velocidade ao Rigidbody2D (movimento f�sico)
    }
}