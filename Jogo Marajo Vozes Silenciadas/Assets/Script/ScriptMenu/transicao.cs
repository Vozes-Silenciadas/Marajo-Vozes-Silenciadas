using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transicao : MonoBehaviour
{
    public TextMeshProUGUI texto1;

    public void ComecarEscrita()
    {
        // Inicia a coroutine para exibir o texto com efeito de máquina de escrever
        StartCoroutine(AparecerTexto());
    }

    IEnumerator AparecerTexto()
    {
        // Armazena o texto original e limpa o campo de texto
        string txt = texto1.text;
        
        texto1.text = "";
               
        int nume = 0;

        while (texto1.text.Length < txt.Length)
        {
            texto1.text += txt.Substring(nume,1);
            nume++;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);
                
    }

    public void ProximaFase()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); // Carrega a proxima cena de forma automatica 
    }
}
