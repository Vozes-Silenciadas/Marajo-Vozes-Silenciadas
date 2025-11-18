using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fim : MonoBehaviour
{
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;


    void Start()
    {
        StartCoroutine(AparecerTexto()); // Inicia a coroutine para exibir o texto com efeito de máquina de escrever
    }

    IEnumerator AparecerTexto()
    {
        // Armazena o texto original e limpa os campos de texto
        string txt = texto1.text;
        string txt1 = texto2.text;

        texto1.text = "";
        texto2.text = "";
        
        int nume = 0;

        while (texto1.text.Length < txt.Length) // Efeito de máquina de escrever para o primeiro texto
        {
            texto1.text += txt.Substring(nume,1);
            nume++;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f); // Pausa antes de começar o segundo texto
        texto1.text = "";   
        nume = 0;

        while (texto2.text.Length < txt1.Length)
        {
            texto2.text += txt1.Substring(nume,1);
            nume++;
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu"); // Volta para o menu
    }

}
