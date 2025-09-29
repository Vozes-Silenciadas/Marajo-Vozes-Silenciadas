using Unity.VisualScripting;
using UnityEngine;
public class Inimigo_Mov : MonoBehaviour
{
    [SerializeField]
    float dirX;
    [SerializeField]
    float dirY;
    [SerializeField]
    Rigidbody2D rb;
    Vector3 localScale;
    Vector2 ele;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //ele = transform.position;

        if (transform.position.x > 3f )
        {
            dirX = 0f;
            dirY = 1f;
        }
        if (transform.position.y > 1.5f)
        {
            dirY = 0f;
            dirX = -1f;
        }
        if (transform.position.x < 0f)
        {
            dirX = 0f;
            dirY = -1f;
        }
        if (transform.position.y < 0f && transform.position.x < 3 )
        {
            dirX = 1f;
            dirY = 0f;
        }
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (dirX, dirY);
    }

}
