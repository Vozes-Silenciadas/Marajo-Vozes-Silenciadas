using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public int vidaStat;                   // Quantidade atual de vida do jogador                    
    public GameObject[] coracoes;           // Array de corações na UI representando a vida
    public GameObject perdeu;

    public GameObject perdeuStat;

    menuControla menuControla;
    void Start()
    {
        menuControla = FindAnyObjectByType<menuControla>();
        if(SceneManager.GetActiveScene().buildIndex != 4) perdeuStat.SetActive(false);
        perdeu.SetActive(false);
        vidaStat = 3;                       // Inicializa a vida do jogador com 3
    }

    void FixedUpdate()
    {
        if (vidaStat <= 0)                  // Se a vida acabar
        {
            perdeu.SetActive(true);
            Time.timeScale = 0;                   // Para o tempo do jogo 
        }
    }

    public void Recarregar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Carrega a cena definida no indice cena   
    }

    public void PerderVida()                 // M�todo chamado para perder uma vida
    {
        Destroy(coracoes[vidaStat - 1]);       // Destroi o coração correspondente a vida atual
        vidaStat--;

        if (SceneManager.GetActiveScene().buildIndex == 4 || vidaStat == 0) return;

        menuControla.Pause();
        perdeuStat.SetActive(true);

    }

    public void VoltarSeguro()
    {
        menuControla.Voltar();
        perdeuStat.SetActive(false);
    }
}