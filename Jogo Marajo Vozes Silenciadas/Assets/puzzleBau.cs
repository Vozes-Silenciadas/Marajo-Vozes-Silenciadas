using System;
using TMPro;
using UnityEngine;

public class puzzleBau : MonoBehaviour
{

    public GameObject puzzle;
    public TextMeshProUGUI[] textosEspaco;
    public GameObject boneca;
    FalaBalao fala;
    int[] respostaCerta;

    void Start()
    {
        puzzle.SetActive(false);
        respostaCerta = new int[4] { 1, 2, 5, 1 };
        fala = FindAnyObjectByType<FalaBalao>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            FechaAbre();
        }
    }

    public void FechaAbre()
    {
        puzzle.SetActive(!puzzle.activeSelf);
    }

    public void TrocarNum(int indexEspaco)
    {
        int numero = Convert.ToInt32(textosEspaco[indexEspaco].text);

        if (numero >= 5) numero = 1;
        else numero++;

        textosEspaco[indexEspaco].text = numero.ToString();
    }
    
    public void VerificarResposta()
    {
        int pontos = 0;
        for (int i = 0; i < textosEspaco.Length; i++)
        {
            if (respostaCerta[i] == Convert.ToInt32(textosEspaco[i].text))
            {
                pontos++;
            }
        }

        if (pontos == 4)
        {
            boneca.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(fala.tempoFechar("Senha incorreta"));
        }

        FechaAbre();
    }
}
