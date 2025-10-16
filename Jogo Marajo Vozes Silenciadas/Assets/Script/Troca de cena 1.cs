using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocadecena1 : MonoBehaviour
{
    public void Cena()
    {
        SceneManager.LoadScene("Fase1");
    }

    float Tempo;
    public TextMeshProUGUI texto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Tempo = 60;  
    }

    // Update is called once per frame
    void Update()
    {
        Tempo -= Time.deltaTime;
        texto.text = $"Tempo: {Tempo.ToString("F0")}";
        
        if (Tempo < 0)
        {
            Cena();
        }
    }
}
