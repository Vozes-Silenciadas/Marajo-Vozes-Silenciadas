using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInicial : MonoBehaviour
{
    public void CarregarCena(int indiCena)
    {
        SceneManager.LoadScene(indiCena);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
