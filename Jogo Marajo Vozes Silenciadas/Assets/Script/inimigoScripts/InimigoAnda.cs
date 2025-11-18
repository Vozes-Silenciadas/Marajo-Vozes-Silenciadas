using UnityEngine;

public class InimigoAnda : MonoBehaviour
{

    public float velo = 3f; // Velocidade do inimigo
    public float tolerancia = 0.1f; // Distância para considerar que chegou ao ponto
    public float grauGiro = 90f; // Grau de rotação para o inimigo olhar em um direcao

    public Transform[] pontosPatrulha; // Pontos que o inimigo irá patrulhar
    public CampoVisao campoVisao; // Armazena o componente campo de visão
    public Transform desenhoVisao; // Referência do transform que contém o desenho da visão

    int indicePontoAtual; // Índice do ponto de patrulha atual
    Rigidbody2D rb; // Corpo rígido do inimigo
    Animator animator; // Referência ao Animator do inimigo

    void Start()
    {
        desenhoVisao = transform.Find("atordoar"); // Procura dentro dos filhos do objeto pelo desenho de visão
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = pontosPatrulha[0].position; // Colocar o inimigo no ponto inicial
        indicePontoAtual = 0;     // Inicia o índice do ponto atual como 0
    }

    void FixedUpdate()
    {
        Patrulhar();
    }

    // -------------------------------Movimentação para IA do Inimigo------------------------//
    void Patrulhar()
    {
        Transform pontoDestino = pontosPatrulha[indicePontoAtual];
        Vector2 direcaoMov = (pontoDestino.position - transform.position).normalized; // Direção do movimento do inimigo
        rb.linearVelocity = direcaoMov * velo;

        float angulo = Mathf.Atan2(direcaoMov.y, direcaoMov.x) * Mathf.Rad2Deg + grauGiro; // Calcula o ângulo de rotação com base na direção do movimento
        desenhoVisao.rotation = Quaternion.Euler(0, 0, angulo); // Aplica a rotação ao desenho da visão

        // Para flipar o sprite
        if (direcaoMov.x > 0) transform.localScale = new Vector3(0.7212328f, 0.7212328f, 0.7212328f);
        else transform.localScale = new Vector3(-0.7212328f, 0.7212328f, 0.7212328f);   

        animator.SetFloat("dirX", direcaoMov.x);
        animator.SetFloat("dirY", direcaoMov.y);             
         
        campoVisao.DirecaoInimigoN(direcaoMov); // Mudar a direção do campo de visão

        if (Vector2.Distance(transform.position, pontoDestino.position) < tolerancia) // Verifica se chegou ao ponto de patrulha
        {
            indicePontoAtual++;
            if (indicePontoAtual >= pontosPatrulha.Length)
            {
                indicePontoAtual = 0;
            }
        }
    }

}
