using Unity.Mathematics;
using UnityEngine;

public class Inimigo_vira : MonoBehaviour
{
    public CampoVisao campoVisao;              // Refer�ncia ao campo de vis�o do inimigo

    public float dirX;                  // Dire��o horizontal do movimento
    public float dirY;                  // Dire��o vertical do movimento

    float tempoAtual;                   // Contador atual para mudar dire��o
    float tempoMax = 3;                 // Tempo m�ximo antes de mudar dire��o
    float cont = 0;                     // Contador de fases de movimenta��o

    void Start()
    {
        tempoAtual = tempoMax;          // Inicializa o contador de tempo
        dirY = -1;                       // Inicialmente o inimigo se move para baixo
    }

    void Update()
    {
        // Atualiza o contador de tempo
        if (tempoAtual < 0)
        {
            tempoAtual = tempoMax;       // Reseta o tempo
            cont++;                       // Passa para a pr�xima fase do movimento
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

        campoVisao.DirecaoInimigo(dirX, dirY); // Atualiza a dire��o do inimigo no script de campo de vis�o
    }
}
