using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    public int vidaStat;                   // Quantidade atual de vida do jogador                    
    public GameObject[] coracoes;           // Array de cora��es na UI representando a vida
    public GameObject perdeu;

    void Start()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // Carrega a cena definida no �ndice cena   
    }

    public void PerderVida()                 // M�todo chamado para perder uma vida
    {
        Destroy(coracoes[vidaStat - 1]);       // Destroi o cora��o correspondente � vida atual
        vidaStat--;
    }
}