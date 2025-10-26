using UnityEngine;

public class menuControla : MonoBehaviour
{

    public GameObject menu;              // Painel do menu de pausa
    static bool jogoPausado = false;     // Indica se o jogo está pausado ou não

    void Start()
    {
        menu.SetActive(false);           // Esconde o menu no início
        jogoPausado = false;             // Garante que o jogo não está pausado ao iniciar
        Time.timeScale = 1;              // Define o tempo do jogo para normal
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Detecta quando o jogador pressiona ESC
        {
            menu.SetActive(!menu.activeSelf);  // Alterna entre mostrar e esconder o menu

            if (jogoPausado)                    // Se o jogo já estava pausado
            {
                Voltar();                       // Retoma o jogo
            }
            else                                // Se o jogo não estava pausado
            {
                Pause();                        // Pausa o jogo
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0;                   // Para o tempo do jogo 
        jogoPausado = true;                   // Marca o jogo como pausado
    }

    void Voltar()
    {
        Time.timeScale = 1;                   // Retoma o tempo do jogo 
        jogoPausado = false;                  // Marca o jogo como não pausado
    }

    public bool Pausado()                      // Método público para outros scripts verificarem se o jogo está pausado
    {
        return jogoPausado;
    }
}
