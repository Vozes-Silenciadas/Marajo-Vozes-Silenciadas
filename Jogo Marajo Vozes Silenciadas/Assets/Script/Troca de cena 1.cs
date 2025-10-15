using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocadecena1 : MonoBehaviour
{
    public void Cena()
    {
        SceneManager.LoadScene("Fase1");
    }
    float Tempo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Tempo = 10;  
    }

    // Update is called once per frame
    void Update()
    {
        Tempo -= Time.deltaTime;
        if (Tempo < 0)
        {
            Cena();
        }
    }
}
