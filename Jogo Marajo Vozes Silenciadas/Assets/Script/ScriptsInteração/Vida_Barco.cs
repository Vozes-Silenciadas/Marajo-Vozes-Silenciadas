using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida_Barco : MonoBehaviour
{
    public int Vidas;
    public GameObject[] coracoes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vidas = 3;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Vidas <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pedra"))
        {
            Destroy(coracoes[Vidas - 1]);
        }
    }
}
