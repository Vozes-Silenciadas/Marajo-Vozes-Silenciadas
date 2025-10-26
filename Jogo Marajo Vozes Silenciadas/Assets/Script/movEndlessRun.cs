using UnityEngine;

public class movEndlessRun : MonoBehaviour
{
    public GameObject[] waypoints;       // Array de posições (waypoints) entre os quais o objeto pode se mover
    public int wayAtual = 0;             // Índice do waypoint atual
    public bool teste;                   // Variável de teste (não utilizada no script)
    menuControla menu;                   // Referência ao script de controle do menu (para verificar pausa)

    void Start()
    {
        transform.position = waypoints[wayAtual].transform.position; // Define a posição inicial do objeto no primeiro waypoint
        menu = FindAnyObjectByType<menuControla>();                   // Busca automaticamente o menuControla na cena
    }

    void Update()
    {
        if (!menu.Pausado())                                         // Só permite movimento se o jogo não estiver pausado
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // Se o jogador apertar D ou seta para a direita
            {
                if (wayAtual < waypoints.Length - 1) wayAtual++;        // Avança para o próximo waypoint, se não estiver no último
                transform.position = waypoints[wayAtual].transform.position; // Move o objeto para o novo waypoint
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // Se o jogador apertar A ou seta para a esquerda
            {
                if (wayAtual > 0) wayAtual--;                         // Volta para o waypoint anterior, se não estiver no primeiro
                transform.position = waypoints[wayAtual].transform.position; // Move o objeto para o waypoint anterior
            }
        }
    }
}