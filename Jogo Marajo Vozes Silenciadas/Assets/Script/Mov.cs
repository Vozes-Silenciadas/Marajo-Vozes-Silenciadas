using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;                   // Rigidbody2D do jogador para movimentação física

    [SerializeField]
    private float vel;                        // Velocidade de movimento do jogador
    private Animator animator;                // Animator do jogador para controlar animações
    private SpriteRenderer sprite;            // SpriteRenderer para inverter o sprite ao andar
    public List<Item> itensInve;              // Lista de itens que o jogador possui no inventário
    private menuControla menu;                // Referência ao script que controla o menu de pausa

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // Pega o Rigidbody2D anexado ao jogador
        animator = GetComponent<Animator>();  // Pega o Animator do jogador
        sprite = GetComponent<SpriteRenderer>(); // Pega o SpriteRenderer do jogador
        menu = FindAnyObjectByType<menuControla>(); // Encontra o menuControla na cena
    }

    void Update()
    {
        if (!menu.Pausado())                  // Só permite movimentação se o jogo não estiver pausado
        {
            float movH = Input.GetAxisRaw("Horizontal"); // Movimento horizontal 
            float movV = Input.GetAxisRaw("Vertical");   // Movimento vertical 

            rb.linearVelocity = new Vector2(movH, movV).normalized * vel; // Aplica velocidade normalizada para diagonal ficar correta

            if (Input.GetKey(KeyCode.LeftShift)) vel = 2;     // Segurando Shift corre
            else if (Input.GetKey(KeyCode.LeftControl)) vel = 0.5f; // Segurando Ctrl anda devagar
            else vel = 1;                                     // Velocidade padrão

            animando(movH, movV);                             // Chama método para controlar animações
        }
    }

    private void animando(float movH, float movV)
    {
        if (movH != 0 || movV != 0)                          // Se houver movimento
        {
            if (movH < 0) sprite.flipX = true;              // Flip horizontal para esquerda
            else if (movH > 0) sprite.flipX = false;       // Flip horizontal para direita

            animator.SetBool("estaAndando", true);         // Ativa animação de andar
            animator.SetFloat("InputX", movH);             // Define eixo X atual
            animator.SetFloat("InputY", movV);             // Define eixo Y atual
            animator.SetFloat("UltimoInputX", movH);       // Salva última direção X para idle
            animator.SetFloat("UltimoInputY", movV);       // Salva última direção Y para idle
        }
        else
        {
            animator.SetBool("estaAndando", false);        // Sem movimento 
        }
    }
}