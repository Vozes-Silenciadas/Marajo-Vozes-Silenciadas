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
        float anguloCentral = Mathf.Atan2(direcaoInimigo.y, direcaoInimigo.x) * Mathf.Rad2Deg;

        // 2. Calcula os ângulos das bordas
        float anguloEsquerdo = anguloCentral + (anguloDeVisao / 2f);
        float anguloDireito = anguloCentral - (anguloDeVisao / 2f);

        // 3. Converte os ângulos das bordas de volta para vetores de direção
        
        Vector2 limiteEsquerdo = AnguloParaVetor(anguloEsquerdo);
        Vector2 limiteDireito = AnguloParaVetor(anguloDireito);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        // 4. Desenha as bordas do cone
        Debug.DrawRay(transform.position, limiteEsquerdo * alcanceDeVisao, Color.blue);
        Debug.DrawRay(transform.position, limiteDireito * alcanceDeVisao, Color.blue);
        
    }

private Vector2 AnguloParaVetor(float angulo)
{
    // Converte o ângulo de volta para radianos
    float anguloRad = angulo * Mathf.Deg2Rad; 
    
    // Retorna o vetor de direção (Cos para X, Sin para Y)
    return new Vector2(Mathf.Cos(anguloRad), Mathf.Sin(anguloRad)).normalized;
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
