using TMPro;
using UnityEngine;

public class puzzleSenhaF4 : MonoBehaviour
{
    public GameObject puzzle;               // Painel do puzzle que ser� ativado/desativado
    public TextMeshProUGUI[] textosEspaco; // Array de textos que mostram os n�meros do puzzle
    int[] respostaCerta;                     // Array que guarda a resposta correta do puzzle

    void Start()
    {
        puzzle.SetActive(false);            // Esconde o puzzle no in�cio
        respostaCerta = new int[3];

        for (int i = 0; i < 3; i++)
        {
            respostaCerta[i] = Random.Range(1, 10);
        }

        for (int i = 0; i < 3; i++)
        {
            Debug.Log(respostaCerta[i]); // saber a senha no debug e testar
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // Dispara quando o jogador colide com o objeto do puzzle
    {
        if (collision.collider.CompareTag("Player")) // Verifica se � o jogador
        {
            FechaAbre();                             // Abre ou fecha o puzzle
        }
    }

    public void FechaAbre()                          // M�todo para alternar o painel do puzzle
    {
        puzzle.SetActive(!puzzle.activeSelf);        // Ativa se estiver desativado, desativa se estiver ativo
    }

    public void TrocarNum(int indexEspaco)          // M�todo para alterar o n�mero de um espa�o do puzzle
    {
        int numero = System.Convert.ToInt32(textosEspaco[indexEspaco].text); // Converte o texto atual para n�mero

        if (numero >= 9) numero = 1;                // Se o n�mero passar de 5, volta para 1
        else numero++;                               // Caso contr�rio, incrementa 1

        textosEspaco[indexEspaco].text = numero.ToString(); // Atualiza o texto no espa�o
    }

    public void VerificarResposta()                  // M�todo para verificar se a combina��o est� correta
    {
        int pontos = 0;                              // Contador de acertos
        for (int i = 0; i < textosEspaco.Length; i++)
        {
            if (respostaCerta[i] == System.Convert.ToInt32(textosEspaco[i].text)) // Compara cada espa�o com a resposta certa
            {
                pontos++;                             // Incrementa pontos se estiver correto
            }
        }

        if (pontos == 3)                             // Se todos os 4 n�meros estiverem corretos
        {
            gameObject.SetActive(false);             // Desativa o objeto do puzzle
        }

        FechaAbre();                                 // Fecha o painel do puzzle
    }
}
