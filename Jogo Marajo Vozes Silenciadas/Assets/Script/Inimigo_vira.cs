using Unity.Mathematics;
using UnityEngine;

public class Inimigo_vira : MonoBehaviour
{
    Rigidbody2D rb;                     // Referência ao Rigidbody2D do inimigo para aplicar movimentação
    Vector3 localScale;                 // Armazena a escala original do inimigo
    inventarioControla inventario;      // Referência ao script de inventário (não utilizado aqui, mas presente)
    public CampoVisao sla;              // Referência ao campo de visão do inimigo

    public float dirX;                  // Direção horizontal do movimento
    public float dirY;                  // Direção vertical do movimento

    float tempoAtual;                   // Contador atual para mudar direção
    float tempoMax = 3;                 // Tempo máximo antes de mudar direção
    float cont = 0;                     // Contador de fases de movimentação

    void Start()
    {
        tempoAtual = tempoMax;          // Inicializa o contador de tempo
        localScale = transform.localScale; // Salva a escala original do inimigo
        rb = GetComponent<Rigidbody2D>(); // Pega o Rigidbody2D do inimigo
        dirY = -1;                       // Inicialmente o inimigo se move para baixo
    }

    void Update()
    {
        // Atualiza o contador de tempo
        if (tempoAtual < 0)
        {
            tempoAtual = tempoMax;       // Reseta o tempo
            cont++;                       // Passa para a próxima fase do movimento
        }
        else
        {
            tempoAtual -= Time.deltaTime; // Diminui o tempo a cada frame
        }

        // Primeira fase do movimento
        if (cont == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90); // Rotaciona o inimigo para a direita
            dirX = 1;                  // Define movimento horizontal para a direita
            dirY = 0;                  // Sem movimento vertical
        }

        // Segunda fase do movimento
        if (cont == 2)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);  // Rotaciona o inimigo para baixo
            cont = 0;                   // Reseta o contador para o ciclo do movimento

            dirX = 0;                   // Sem movimento horizontal
            dirY = -1;                  // Movimento para baixo
        }

        sla.DirecaoInimigo(dirX, dirY); // Atualiza a direção do inimigo no script de campo de visão
    }
}
