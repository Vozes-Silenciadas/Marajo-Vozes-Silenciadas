using UnityEngine;

public class Inimigo_vira : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 localScale;
    float tempoAtual;
    float tempoMax = 3;
    float cont = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoAtual = tempoMax;
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoAtual < 0)
        {
            tempoAtual = tempoMax;
            cont++;
        }
        else
        {
            tempoAtual-= Time.deltaTime;
        }
        if (cont == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90);
        }
        if (cont == 2)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            cont = 0;
        }

    }
}
