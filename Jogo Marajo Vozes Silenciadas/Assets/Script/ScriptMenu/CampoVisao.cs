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

        Vector2 direcaoAoJogador = (alvoJogador.position - transform.position).normalized;
        float distanciaAoJogador = Vector2.Distance(transform.position, alvoJogador.position);

        if (distanciaAoJogador > alcanceDeVisao)
        {
            return false;
        }

        float anguloEntreInimigoEJogador = Vector2.Angle(direcaoInimigo, direcaoAoJogador);

        if (anguloEntreInimigoEJogador > anguloDeVisao / 2f)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,direcaoAoJogador,distanciaAoJogador,layerObstaculo);

        if (hit.collider != null)
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
        direcaoInimigo = new Vector2(dirX, dirY);
    }
    
    public void DirecaoInimigoN(Vector2 direcao)
    {
        direcaoInimigo = direcao;
    }
}
