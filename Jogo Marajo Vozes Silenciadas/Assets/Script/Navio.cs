using UnityEngine;
using UnityEngine.SceneManagement;

public class Navio : MonoBehaviour
{
    float dirY = -2f;
    float tempo = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if(tempo <= 0)
        {
            transform.Translate(new Vector2(0, dirY * Time.deltaTime));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Moacir"))
        {
            SceneManager.LoadScene("Fase4");
        }
    }
}
