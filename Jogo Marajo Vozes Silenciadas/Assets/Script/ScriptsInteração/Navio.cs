using UnityEngine;
using UnityEngine.SceneManagement;

public class Navio : MonoBehaviour
{
    float dirY = -2f;
    float tempo = 60;

    void Update()
    {
        // Move o navio para baixo após o tempo determinado
        tempo -= Time.deltaTime;
        if(tempo <= 0)
        {
            transform.Translate(new Vector2(0, dirY * Time.deltaTime));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com o jogador para trocar de cena
        if (collision.gameObject.name.Equals("Moacir"))
        {
            SceneManager.LoadScene("Fase4");
        }
    }
}
