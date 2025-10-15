using Unity.Mathematics;
using UnityEngine;

public class Inimigo_vira : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 localScale;
    inventarioControla inventario;
    public CampoVisao sla;

    public float dirX;
    public float dirY;

    float tempoAtual;
    float tempoMax = 3;
    float cont = 0;

    void Start()
    {
        tempoAtual = tempoMax;
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirY = -1;       
    }

    void Update()
    {

        if (tempoAtual < 0)
        {
            tempoAtual = tempoMax;
            cont++;
        }
        else
        {
            tempoAtual -= Time.deltaTime;
        }
        if (cont == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90);
            dirX = 1;
            dirY = 0;
        }
        if (cont == 2)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            cont = 0;

            dirX = 0;
            dirY = -1;
        }

        sla.DirecaoInimigo(dirX,dirY);
    }

}
