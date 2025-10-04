using Unity.VisualScripting;
using UnityEngine;
public class Inimigo_Mov : MonoBehaviour
{
    float dirX;
    float dirY;
    Rigidbody2D rb;
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = 1f;
      
    }



    void Update()
    {

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
        rb.linearVelocity = new Vector2(dirX, dirY);
    }


}
