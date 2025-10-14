using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class Inimigo_Mov : MonoBehaviour
{
    public float dirX;
    public float dirY;
    float dirZ;
    Rigidbody2D rb;
    Vector3 localScale;
    public Transform[] pontosPatrulha;

    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();

        transform.position = pontosPatrulha[0].position; 
        dirX = 1f;
    }
    
    void Update()
    {

        if (transform.localPosition.x > pontosPatrulha[1].localPosition.x )
        {
            dirX = 0f;
            dirY = 1f;
            transform.rotation = Quaternion.Euler(dirX, dirY, 180);
        }
        if (transform.localPosition.y > pontosPatrulha[2].localPosition.y)
        {
            dirY = 0f;
            dirX = -1f;
            transform.rotation = Quaternion.Euler(dirX, dirY, -90);
        }
        if (transform.localPosition.x < pontosPatrulha[3].localPosition.x)
        {
            dirX = 0f;
            dirY = -1f;
            transform.rotation = Quaternion.Euler(dirX, dirY, 0);
        }
        if (transform.localPosition.x < pontosPatrulha[0].localPosition.x && transform.localPosition.y < pontosPatrulha[0].localPosition.y )
        {
            dirX = 1f;
            dirY = 0f;
            transform.rotation = Quaternion.Euler(dirX, dirY, 90);
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX, dirY);
    }


}
