using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float vel;
    private Animator animator;
    private SpriteRenderer sprite;
    public List<Item> itensInve;
    private menuControla menu;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        menu = FindAnyObjectByType<menuControla>();
    }

    void Update()
    {
        if (!menu.Pausado())
        {
            float movH = Input.GetAxisRaw("Horizontal");
            float movV = Input.GetAxisRaw("Vertical");

            rb.linearVelocity = new Vector2(movH, movV).normalized * vel;

            if (Input.GetKey(KeyCode.LeftShift)) vel = 2;
            else if (Input.GetKey(KeyCode.LeftControl)) vel = 0.5f;
            else vel = 1;

            animando(movH, movV);
        }

    }

    private void animando(float movH, float movV)
    {
        if (movH != 0 || movV != 0)
        {
            if (movH < 0) sprite.flipX = true;
            else if (movH > 0) sprite.flipX = false;

            animator.SetBool("estaAndando", true);
            animator.SetFloat("InputX", movH);
            animator.SetFloat("InputY", movV);
            animator.SetFloat("UltimoInputX", movH);
            animator.SetFloat("UltimoInputY", movV);
        }
        else
        {
            animator.SetBool("estaAndando", false);
        }
    }

  
}
