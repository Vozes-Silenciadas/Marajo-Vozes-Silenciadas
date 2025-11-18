using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour
{
    public void CarregarCena(int indiCena)        // Método para carregar uma cena pelo indice
    {
        SceneManager.LoadScene(indiCena);        // Carrega a cena correspondente ao indice passado
    }

    public void abrirFecharAba(GameObject aba)   // Método para alternar a visibilidade de uma aba
    {
        aba.SetActive(!aba.activeSelf);          // Ativa a aba se estiver desativada ou desativa se estiver ativa
    }

    public void FecharJogo()                     // Método para fechar o jogo
    {
        Application.Quit();                       // Fecha o jogo
    }
}
