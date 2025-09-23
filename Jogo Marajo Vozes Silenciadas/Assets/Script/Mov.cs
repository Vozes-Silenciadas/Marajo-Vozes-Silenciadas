using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(movH, movV);
        
    }
}
