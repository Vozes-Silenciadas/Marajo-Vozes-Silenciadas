using UnityEngine;

public class Barco : MonoBehaviour
{
    float speed = 5f;
 
    void Update()
    {
        float V = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2 (V * speed*Time.deltaTime, 0));
    }
}
