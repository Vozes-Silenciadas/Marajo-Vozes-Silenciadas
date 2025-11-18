using UnityEngine;

public class Barco : MonoBehaviour
{
    float speed = 5f;
 
    void Update()
    {
        // Movimenta o barco horizontalmente com base na entrada do jogador
        float V = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2 (V * speed*Time.deltaTime, 0));
    }
}
