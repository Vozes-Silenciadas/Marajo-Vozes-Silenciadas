using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;                   // Rigidbody2D do jogador para movimenta��o f�sica

    float vel, movH, movV;                        // Velocidade de movimento do jogador
    private Animator animator;                // Animator do jogador para controlar anima��es
    private SpriteRenderer sprite;            // SpriteRenderer para inverter o sprite ao andar
    public List<Item> itensInve;              // Lista de itens que o jogador possui no invent�rio
    private menuControla menu;                // Refer�ncia ao script que controla o menu de pausa

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // Pega o Rigidbody2D anexado ao jogador
        animator = GetComponent<Animator>();  // Pega o Animator do jogador
        sprite = GetComponent<SpriteRenderer>(); // Pega o SpriteRenderer do jogador
        menu = FindAnyObjectByType<menuControla>(); // Encontra o menuControla na cena
    }

    void Update()
    {
        if (!menu.Pausado())                  // S� permite movimenta��o se o jogo n�o estiver pausado
        {
            movH = Input.GetAxisRaw("Horizontal"); // Movimento horizontal 
            movV = Input.GetAxisRaw("Vertical");   // Movimento vertical 

            rb.linearVelocity = new Vector2(movH, movV).normalized * vel; // Aplica velocidade normalizada para diagonal ficar correta

            if (Input.GetKey(KeyCode.LeftShift)) vel = 2;     // Segurando Shift corre
            else if (Input.GetKey(KeyCode.LeftControl)) vel = 0.5f; // Segurando Ctrl anda devagar
            else vel = 1;                                     // Velocidade padr�o

            animando(movH, movV);                             // Chama m�todo para controlar anima��es
        }
    }

    public bool estaMovendo()
    {
        if (movH != 0 || movV != 0)
        {
            return true;
        }
        return false;
    }

    private void animando(float movH, float movV)
    {
        if (movH != 0 || movV != 0)                          // Se houver movimento
        {
            if (movH < 0) sprite.flipX = true;              // Flip horizontal para esquerda
            else if (movH > 0) sprite.flipX = false;       // Flip horizontal para direita

            animator.SetBool("estaAndando", true);         // Ativa anima��o de andar
            animator.SetFloat("InputX", movH);             // Define eixo X atual
            animator.SetFloat("InputY", movV);             // Define eixo Y atual
            animator.SetFloat("UltimoInputX", movH);       // Salva �ltima dire��o X para idle
            animator.SetFloat("UltimoInputY", movV);       // Salva �ltima dire��o Y para idle
        }
        else
        {
            animator.SetBool("estaAndando", false);        // Sem movimento 
        }
    }

}