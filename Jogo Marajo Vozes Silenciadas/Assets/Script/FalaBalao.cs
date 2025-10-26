using System.Collections;
using TMPro;
using UnityEngine;

public class FalaBalao : MonoBehaviour
{

    public GameObject balaoDeFala;          // Referência ao GameObject que representa o balão de fala
    public TextMeshProUGUI texto;           // Referência ao texto dentro do balão 

    public IEnumerator tempoFechar(string fala)  // Corrotina que mostra o balão com a fala e fecha depois de um tempo
    {
        texto.text = fala;                  // Define o texto do balão com a mensagem recebida
        balaoDeFala.SetActive(true);        // Ativa o balão para que fique visível na tela
        yield return new WaitForSeconds(3f); // Espera 3 segundos antes de continuar
        balaoDeFala.SetActive(false);       // Desativa o balão, fazendo-o desaparecer da tela
    }
}
