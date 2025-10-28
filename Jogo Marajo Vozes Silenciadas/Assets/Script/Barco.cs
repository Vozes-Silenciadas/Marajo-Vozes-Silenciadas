using UnityEngine;

public class Barco : MonoBehaviour
{
    float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float V = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2 (V * speed, 0));
    }
}
