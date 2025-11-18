using UnityEngine;

public class CampoVisao : MonoBehaviour
{
    public Transform alvoJogador;
    public Transform localSeguro;
    public float alcanceDeVisao = 1f;
    public float anguloDeVisao = 60f;

    public LayerMask layerObstaculo;
    public Vector2 direcaoInimigo;
    bool jogadorDetectado = false;
    vida vida;

    void Start()
    {
        alvoJogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        vida = FindAnyObjectByType<vida>();
    }
    void Update()
    {
        // Verifica se o jogador está dentro do campo de visão do inimigo
        jogadorDetectado = VerificarVisao();

        if (jogadorDetectado)
        {
            alvoJogador.position = localSeguro.position;            
            vida.PerderVida();
        }
    }

    private bool VerificarVisao()
    {
        if (alvoJogador == null) return false;

        DebugarLimitesDoCone();

        // Calcula a direção do inimigo e do jogador
        Vector2 direcaoAoJogador = (alvoJogador.position - transform.position).normalized;
        float distanciaAoJogador = Vector2.Distance(transform.position, alvoJogador.position);

        if (distanciaAoJogador > alcanceDeVisao) // Verifica se o jogador está fora do alcance de visão
        {
            return false;
        }

        float anguloEntreInimigoEJogador = Vector2.Angle(direcaoInimigo, direcaoAoJogador); // Calcula o ângulo entre a direção do inimigo e a direção ao jogador

        if (anguloEntreInimigoEJogador > anguloDeVisao / 2f) // Verifica se o jogador está fora do ângulo de visão
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,direcaoAoJogador,distanciaAoJogador,layerObstaculo);

        if (hit.collider != null) // Verifica se há um obstáculo bloqueando a visão até o jogador
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void DebugarLimitesDoCone()
    {
        // Calcula os limites esquerdo e direito do cone de visão
        Quaternion rotacaoEsquerda = Quaternion.Euler(0, 0, anguloDeVisao / 2f);
        Vector2 limiteEsquerdo = rotacaoEsquerda * direcaoInimigo;

        Quaternion rotacaoDireita = Quaternion.Euler(0, 0, -anguloDeVisao / 2f);
        Vector2 limiteDireito = rotacaoDireita * direcaoInimigo;

        // Desenha as bordas do cone
        Debug.DrawRay(transform.position, limiteEsquerdo * alcanceDeVisao, Color.blue);
        Debug.DrawRay(transform.position, limiteDireito * alcanceDeVisao, Color.blue);
    }

    public void DirecaoInimigo(float dirX, float dirY)
    {
        // Define a direção do inimigo com base nos valores fornecidos
        direcaoInimigo = new Vector2(dirX, dirY);
    }
    
    public void DirecaoInimigoN(Vector2 direcao)
    {
        direcaoInimigo = direcao;
    }
}
