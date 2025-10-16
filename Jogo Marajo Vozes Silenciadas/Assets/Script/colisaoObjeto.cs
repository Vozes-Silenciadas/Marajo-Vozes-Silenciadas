using UnityEngine;

public class colisaoObjeto : MonoBehaviour
{
    vida vida;

    void Start()
    {
        vida = FindAnyObjectByType<vida>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Objeto"))
        {
            vida.vidaStat--;
            Debug.Log("Vida Atual: " + vida.vidaStat);
        }
    }
}
