using System;
using UnityEngine;
using UnityEngine.UI;

public class abaControla : MonoBehaviour
{
    public Image[] abaImage;   // Array que guarda as imagens das abas
    public GameObject[] paginas; //Array que guarda as páginas correspondentes às abas

    void Start()
    {
        AtivarAba(0);// Ao iniciar o jogo, a primeira aba (índice 0) é ativada
    }

    public void AtivarAba(int abaNum)                // Método responsável por ativar a aba e página selecionadas
    {
        for (int i = 0; i < paginas.Length; i++)   // Percorre todas as páginas e abas
        { 
            paginas[i].SetActive(false);          // Desativa todas as páginas
            abaImage[i].color = Color.grey;      // Desativa todas as páginas e muda todas as abas para a cor cinza 
        }
        paginas[abaNum].SetActive(true);       // Ativa apenas a aba e página escolhidas
        abaImage[abaNum].color = Color.white; // Muda a cor da aba ativa para branco (indicando selecionada)
    }
}
