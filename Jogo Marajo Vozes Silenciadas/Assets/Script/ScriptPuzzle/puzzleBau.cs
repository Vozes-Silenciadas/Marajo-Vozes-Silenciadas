using System;
using TMPro;
using UnityEngine;

public class puzzleBau : MonoBehaviour
{

    public GameObject puzzle;               // Painel do puzzle que será ativado/desativado
    public TextMeshProUGUI[] textosEspaco; // Array de textos que mostram os numeros do puzzle
    public GameObject boneca;               // Objeto que aparece quando o puzzle é resolvido
    FalaBalao fala;                         // Referencia ao script de balão de fala para mensagens
    int[] respostaCerta;                     // Array que guarda a resposta correta do puzzle

    void Start()
    {
        puzzle.SetActive(false);            // Esconde o puzzle no inicio
        respostaCerta = new int[4] { 1, 2, 5, 1 }; // Define a combinação correta
        fala = FindAnyObjectByType<FalaBalao>();    // Busca o script de balão de fala na cena
    }

    void OnCollisionEnter2D(Collision2D collision) // Dispara quando o jogador colide com o objeto do puzzle
    {
        if (collision.collider.CompareTag("Player")) // Verifica se tocou o jogador
        {
            FechaAbre();                             // Abre ou fecha o puzzle
        }
    }

    public void FechaAbre()                          // Metodo para alternar o painel do puzzle
    {
        puzzle.SetActive(!puzzle.activeSelf);        // Ativa se estiver desativado, desativa se estiver ativo
    }

    public void TrocarNum(int indexEspaco)          // Metodo para alterar o numero de um espaço do puzzle
    {
        int numero = Convert.ToInt32(textosEspaco[indexEspaco].text); // Converte o texto atual para numero

        if (numero >= 5) numero = 1;                // Se o numero passar de 5, volta para 1
        else numero++;                               // Caso contrario, incrementa 1

        textosEspaco[indexEspaco].text = numero.ToString(); // Atualiza o texto no espaço
    }

    public void VerificarResposta()                  // Metodo para verificar se a combinação esta correta
    {
        int pontos = 0;                              // Contador de acertos
        for (int i = 0; i < textosEspaco.Length; i++)
        {
            if (respostaCerta[i] == Convert.ToInt32(textosEspaco[i].text)) // Compara cada espaço com a resposta certa
            {
                pontos++;                             // Incrementa pontos se estiver correto
            }
        }

        if (pontos == 4)                             // Se todos os 4 números estiverem corretos
        {
            boneca.SetActive(true);                  // Ativa a boneca como recompensa
            gameObject.SetActive(false);             // Desativa o objeto do puzzle
        }
        else
        {
            StartCoroutine(fala.tempoFechar("Senha incorreta")); // Mostra mensagem de erro
        }

        FechaAbre();                                 // Fecha o painel do puzzle
    }
} 