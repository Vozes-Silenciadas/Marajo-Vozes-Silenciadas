using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour
{
    public void CarregarCena(int indiCena)
    {
        SceneManager.LoadScene(indiCena);
    }

    public void abrirFecharAba(GameObject aba)
    {
        aba.SetActive(!aba.activeSelf);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
