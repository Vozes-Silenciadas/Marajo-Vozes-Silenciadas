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
        StartCoroutine(AparecerTexto1());
    }

    IEnumerator AparecerTexto1()
    {
        string txt = texto1.text;
        string txt1 = texto2.text;

        texto1.text = "";
        texto2.text = "";
        
        int nume = 0;

        while (texto1.text.Length < txt.Length)
        {
            texto1.text += txt.Substring(nume,1);
            nume++;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.25f);
                
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
        SceneManager.LoadScene("Menu");
    }
}
