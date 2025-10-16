using UnityEngine;
using UnityEngine.SceneManagement;

public class concluirFase : MonoBehaviour
{
    Coleta_itens pistass;
    public FalaBalao fala;

    void Start()
    {
        fala = FindAnyObjectByType<FalaBalao>();
        pistass = FindAnyObjectByType<Coleta_itens>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (pistass.contaPista >= 6)
            {
                SceneManager.LoadScene(3);
            } else
            {
                StartCoroutine(fala.tempoFechar("Preciso de mais pistas"));
                Debug.Log("sla");
            }
        }
    }
}
