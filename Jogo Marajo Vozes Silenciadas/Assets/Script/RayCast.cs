using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform alvoJogador;
    public float alcanceDeVisao = 1f;
    public float anguloDeVisao = 60f;

    public LayerMask layerObstaculo;
    Vector2 direcaoInimigo;
    bool jogadorDetectado = false;
    public Inimigo_Mov mov;


    void Update()
    {
        jogadorDetectado = VerificarVisao();

        if (jogadorDetectado)
        {
            Debug.Log("JOGADOR DETECTADO! Alerta!");
        }
    }

    private bool VerificarVisao()
    {
        direcaoInimigo = new Vector2(mov.dirX, mov.dirY);
        DebugarLimitesDoCone();
        
        if (alvoJogador == null) return false;

        Vector2 direcaoAoJogador = (alvoJogador.position - transform.position).normalized;
        float distanciaAoJogador = Vector2.Distance(transform.position, alvoJogador.position);

        if (distanciaAoJogador > alcanceDeVisao)
        {
            Debug.DrawRay(transform.position, direcaoAoJogador * distanciaAoJogador, Color.red);
            return false;
        }

        float anguloEntreInimigoEJogador = Vector2.Angle(direcaoInimigo, direcaoAoJogador);

        if (anguloEntreInimigoEJogador > anguloDeVisao / 2f)
        {
            Debug.DrawRay(transform.position, direcaoAoJogador * distanciaAoJogador, Color.cyan);
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direcaoAoJogador,
            distanciaAoJogador,
            layerObstaculo
        );

        if (hit.collider != null)
        {
            Debug.DrawRay(transform.position, direcaoAoJogador * hit.distance, Color.yellow, 0f);
            return false;
        }
        else
        {
            Debug.DrawRay(transform.position, direcaoAoJogador * distanciaAoJogador, Color.green, 0f);
            return true;
        }

       
    }

    void DebugarLimitesDoCone()
    {
        Vector2 frente = transform.up; 
        
        Quaternion rotacaoEsquerda = Quaternion.Euler(0, 0, anguloDeVisao / 2f);
        Vector2 limiteEsquerdo = rotacaoEsquerda * direcaoInimigo;

        Quaternion rotacaoDireita = Quaternion.Euler(0, 0, -anguloDeVisao / 2f);
        Vector2 limiteDireito = rotacaoDireita * direcaoInimigo;

        // Desenha as bordas do cone
        Debug.DrawRay(transform.position, limiteEsquerdo * alcanceDeVisao, Color.blue);
        Debug.DrawRay(transform.position, limiteDireito * alcanceDeVisao, Color.blue);
    }
}
