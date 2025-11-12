using UnityEngine;

public class InimigoAnda : MonoBehaviour
{
    // Start is  once before the first execution of Update after the MonoBehaviour is created
    public float velo = 3f;
    public float tolerancia = 0.1f;
    public float grauGiro = 90f;

    public Transform[] pontosPatrulha;
    public CampoVisao campoVisao;
    public Transform desenhoVisao;

    int indicePontoAtual;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        desenhoVisao = transform.Find("atordoar");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = pontosPatrulha[0].position;
        indicePontoAtual = 0;    
    }

    void FixedUpdate()
    {
        Patrulhar();
    }

    void Patrulhar()
    {
        Transform pontoDestino = pontosPatrulha[indicePontoAtual];
        Vector2 direcaoMov = (pontoDestino.position - transform.position).normalized;
        rb.linearVelocity = direcaoMov * velo;

        float angulo = Mathf.Atan2(direcaoMov.y, direcaoMov.x) * Mathf.Rad2Deg + grauGiro;
        desenhoVisao.rotation = Quaternion.Euler(0, 0, angulo);

        if (direcaoMov.x > 0) transform.localScale = new Vector3(0.7212328f, 0.7212328f, 0.7212328f);
        else transform.localScale = new Vector3(-0.7212328f, 0.7212328f, 0.7212328f);   

        animator.SetFloat("dirX", direcaoMov.x);
        animator.SetFloat("dirY", direcaoMov.y);             
         
        campoVisao.DirecaoInimigoN(direcaoMov);

        if (Vector2.Distance(transform.position, pontoDestino.position) < tolerancia)
        {
            indicePontoAtual++;
            if (indicePontoAtual >= pontosPatrulha.Length)
            {
                indicePontoAtual = 0;
            }
        }
    }

}
