using UnityEngine;

public class atordoar : MonoBehaviour // Script responsável por permitir que o jogador atordoe um inimigo temporariamente
{
    inventarioControla inventario;                     // Referência ao script de inventário do jogador
    bool atordoado = false;                            // Indica se o inimigo está atordoado
    float tempoAtor;                                   // Tempo atual do atordoamento
    float tempoMaxAtor = 2f;                           // Duração máxima do atordoamento
    MonoBehaviour[] scripts;                           // Guarda todos os scripts do inimigo
    Rigidbody2D rb;                                    // Corpo rígido do inimigo
     Transform pai;

    public GameObject Z;                               // Prefab do “Z” que aparece durante o atordoamento
    public bool jogadorEstaNaArea;                     // Indica se o jogador está próximo
    public int ItemParaAtordoar;                       // ID do item necessário para atordoar

    void Start()
    {
        pai = transform.parent;                        // Obtém o transform do objeto pai
        inventario = FindAnyObjectByType<inventarioControla>(); // Encontra o script de inventário na cena
        rb = GetComponentInParent<Rigidbody2D>();      // Obtém o Rigidbody2D do inimigo
        scripts = pai.GetComponents<MonoBehaviour>();  // Armazena todos os scripts do inimigo
    }

    void Update()
    {
        if (atordoado)                                 // Se o inimigo estiver atordoado
        {
            if (tempoAtor < 0)                         // Quando o tempo de atordoamento acabar
            {
                atordoado = false;                     // Deixa de estar atordoado
                LigarOuDesligar();                     // Reativa os scripts
            }
            else
            {
                tempoAtor -= Time.deltaTime;            // Diminui o tempo restante a cada frame
            }
        }

        AtordoarInimigo();                             // Verifica se o jogador tenta atordoar o inimigo
    }

    public void AtordoarInimigo()
    {
        if (jogadorEstaNaArea && Input.GetKeyDown(KeyCode.Space) && !atordoado) // Se o jogador estiver na área e apertar Espaço
        {
            if (inventario.verificarItem(ItemParaAtordoar))      // Se o jogador tiver o item necessário
            {
                atordoado = true;                                // Marca o inimigo como atordoado
                tempoAtor = tempoMaxAtor;                        // Define o tempo máximo do atordoamento
                float x = 0.15f, y = 0.25f;                      // Posição inicial dos “Z”
                float tempoDes = 1.9f;                           // Tempo de duração do efeito visual
                LigarOuDesligar();                               // Desativa os scripts do inimigo
                rb.linearVelocity = Vector2.zero;                // Para o movimento do inimigo

                for (int i = 0; i < 3; i++)                      // Cria três ícones “Z” sobre o inimigo
                {
                    GameObject novoZ = Instantiate(Z, transform.transform); // Instancia o “Z” como filho do inimigo
                    novoZ.transform.localPosition = new Vector2(x, y);      // Define a posição local
                    novoZ.transform.localScale = new Vector2(0.5f, 0.5f);   // Define o tamanho do “Z”
                    Destroy(novoZ, tempoDes);                                // Destroi o “Z” após um tempo
                    tempoDes -= 0.64f;                                       // Diminui o tempo de destruição
                    x -= 0.15f;                                              // Ajusta a posição para o próximo “Z”
                }
            }
            else
            {
                Debug.Log("Você não tem nada para atordoar");     // Mensagem caso o jogador não tenha o item
            }
        }
    }

    public void LigarOuDesligar()
    {
        foreach (MonoBehaviour mono in scripts)                   // Percorre todos os scripts do inimigo
        {
            mono.enabled = !mono.enabled;                        // Alterna entre ativar/desativar cada script
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))                          // Quando o jogador entra na área
        {
            jogadorEstaNaArea = true;                            // Marca que o jogador está próximo
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))                        // Quando o jogador sai da área
        {
            jogadorEstaNaArea = false;                           // Marca que o jogador não está mais próximo
        }
    }
}